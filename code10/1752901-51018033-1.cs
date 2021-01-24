    public partial class MyOwnerForm : Form
    {
        public MyOwnerForm()
        {
            InitializeComponent();
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(100, 100);
            this.ClientSize = new Size(330, 330);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CreateForm(1, new Point(10, 10), new Size(150, 150)).Show();
            CreateForm(0.75, new Point(170, 10), new Size(150, 150)).Show();
            CreateForm(0.50, new Point(10, 170), new Size(150, 150)).Show();
            CreateForm(0.25, new Point(170, 170), new Size(150, 150)).Show();
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if(OwnedForms.Length>0)
            {
                var p = PointToScreen(new Point(10, 10));
                var dx = p.X - OwnedForms[0].Location.X;
                var dy = p.Y - OwnedForms[0].Location.Y;
                foreach (var f in OwnedForms)
                    f.Location= new Point(f.Location.X+dx, f.Location.Y+dy);
            }
        }
        Form CreateForm(double opacity, Point location, Size size)
        {
            var f = new Form();
            f.FormBorderStyle = FormBorderStyle.None;
            f.BackColor = Color.Lime;
            f.Opacity = opacity;
            f.StartPosition = FormStartPosition.Manual;
            f.DesktopLocation = PointToScreen(location);
            f.ClientSize = size;
            f.Owner = this;
            f.ShowInTaskbar = false;
            return f;
        }
    }
