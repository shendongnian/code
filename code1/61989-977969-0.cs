    public partial class Form1 : Form
    {
        private bool go;
        private int dx = 1;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (go)
            {
                this.Location = new Point(this.Location.X + dx, this.Location.Y);
                if (Location.X < 10 || Location.X > 1200)
                {
                    go = false;
                    dx = -dx;
                }
                else
                {
                    this.Invalidate();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            go = true;
            this.Invalidate();
        }
    }
