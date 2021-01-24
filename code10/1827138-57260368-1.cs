    public partial class Form1 : Form
    {
        private static readonly string[] colors =
            new string[] { "#FFFF0000", "#FF00FF00", "#FF0000FF", "#FFFFFF00", "#FFFF00FF", "#FF00FFFF" };
        private static readonly byte[] pixels =
            new byte[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        private static readonly byte scale = 10;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int p = 0, x = 0, y = 0; p < pixels.Length; p++, x += scale)
            {
                if (x > 255)
                {
                    x = 0;
                    y += scale;
                }
                using (var brush = new SolidBrush(ColorTranslator.FromHtml(colors[pixels[p]])))
                    e.Graphics.FillRectangle(brush, x, y, scale, scale);
            }
        }
    }
