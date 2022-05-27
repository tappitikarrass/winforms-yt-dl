using YoutubeExplode;
using YoutubeExplode.Converter;

namespace youtube_dl_gui
{
    public partial class Form1 : Form
    {
        private YoutubeClient _yt;
        public Form1()
        {
            _yt = new YoutubeClient();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var video = await _yt.Videos.GetAsync(textBox1.Text);
                await _yt.Videos.DownloadAsync(textBox1.Text,
                    $"C:\\Users\\stepanbandera\\Desktop\\{video.Title}.{comboBox1.Text}");
            }
            catch (ArgumentException)
            {
            }

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var video = await _yt.Videos.GetAsync(textBox1.Text);
                pictureBox1.ImageLocation = $"https://img.youtube.com/vi/{video.Id}/mqdefault.jpg";

                textBox2.Text = "Title: " + video.Title +
                    "\r\nAuthor: " + video.Author +
                    "\r\nDuration: " + video.Duration +
                    "\r\n\r\nDescription:\r\n" + video.Description + "\r\n";

            }
            catch (ArgumentException)
            {
            }
        }
    }
}