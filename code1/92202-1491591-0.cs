    public partial class Form1 : Form
    {
        IImage smallImage;
        Bitmap bmp = new Bitmap(240, 320);
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            IImage fullSizeImage;
            IImagingFactory factory = new ImagingFactoryClass();
            factory.CreateImageFromFile(@"\My Documents\My Pictures\luminous opera house.jpg", out fullSizeImage);
    
            fullSizeImage.GetThumbnail(240, 320, out smallImage);
    
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                IntPtr hdc = gfx.GetHdc();
                try
                {
                    smallImage.Draw(hdc, new Rectangle(0, 0, 240, 320), IntPtr.Zero);
                }
                finally
                {
                    gfx.ReleaseHdc(hdc);
                }
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
