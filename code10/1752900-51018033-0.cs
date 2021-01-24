    public partial class MyLayeredForm : PerPixelAlphaForm
    {
        public MyLayeredForm()
        {
            InitializeComponent();
            var bm = new Bitmap(230, 230);
            using (var g = Graphics.FromImage(bm))
            {
                using (var b = new SolidBrush(Color.FromArgb(255, Color.Lime)))
                    g.FillRectangle(b, 10, 10, 100, 100);
                using (var b = new SolidBrush(Color.FromArgb(255 * 75 / 100, Color.Lime)))
                    g.FillRectangle(b, 120, 10, 100, 100);
                using (var b = new SolidBrush(Color.FromArgb(255 * 50 / 100, Color.Lime)))
                    g.FillRectangle(b, 10, 120, 100, 100);
                using (var b = new SolidBrush(Color.FromArgb(255 * 25 / 100, Color.Lime)))
                    g.FillRectangle(b, 120, 120, 100, 100);
            }
            this.SelectBitmap(bm);
        }
    }
