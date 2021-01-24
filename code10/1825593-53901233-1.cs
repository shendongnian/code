    public partial class Monitor4 : Form
    {
        public void UpdatePictureBox(string BitmapImage)
        {
            if (File.Exists(BitmpImage))
            {
                if (this.pictureBox1.Image != null)
                    this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = (Image)Image.FromFile(BitmapImage, true).Clone();
            }
        }
    }
