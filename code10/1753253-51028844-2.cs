    public partial class Form1 : Form
    {
        Rectangle circle;
        List<Panel> panels;
        List<int> angles;
        Point center = new Point(300, 300);
        int radius = 200;
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
            panels = Enumerable.Range(0, 9).Select(x => new Panel()
            {
                Size = new Size(100, 40), BackColor = Color.LightSkyBlue
            }).ToList();
            this.Controls.AddRange(panels.ToArray());
            angles = Enumerable.Range(0, 9).Select(x => 90 + x * 40).ToList();
            circle = new Rectangle(center.X - radius, center.Y - radius,
                2 * radius, 2 * radius);
            for (int i = 0; i < 9; i++)
            {
                var x = (int)(radius * Math.Cos(Math.PI * angles[i] / 180.0)) + center.X;
                var y = center.Y - (int)(radius * Math.Sin(Math.PI * angles[i] / 180.0));
                panels[i].Left = x - (panels[i].Width / 2);
                panels[i].Top = y - (panels[i].Height / 2);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(Pens.Red, circle);
        }
    }
