    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Bitmap one = new Bitmap(113, 18);
            using (Graphics g = Graphics.FromImage(one))
            {
                g.FillRectangle(Brushes.Red, 0, 0, 113, 18);
                g.DrawString("ONE", new Font("Arial", 7), Brushes.Black, new RectangleF(0, 0, 113, 18), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            Bitmap two = new Bitmap(113, 18, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(two))
            {
                g.FillRectangle(Brushes.Yellow, 0, 0, 113, 18);
                g.DrawString("TWO", new Font("Arial", 7), Brushes.Black, new RectangleF(0, 0, 113, 18), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            
            BackgroundImageLayout = ImageLayout.Center;
            BackgroundImage = MergeTwoImages(one, two);
        }
        public Bitmap MergeTwoImages(Image firstImage, Bitmap secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }
            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }
            int outputImageWidth = firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;
            int outputImageHeight = firstImage.Height + secondImage.Height + 1;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(firstImage, new Point(0, 0));
                graphics.DrawImage(secondImage, new Point(0, firstImage.Height + 1));
            }
            return outputImage;
        }
    }
