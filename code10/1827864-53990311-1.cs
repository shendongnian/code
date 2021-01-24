    public partial class PinPanel : UserControl
    {
        public PinPanel()
        {
            InitializeComponent();
        }
        private void PinPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(new Point(0, 0), new Size(this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
            e.Graphics.DrawEllipse(Pens.Black, rc);
        }
        private void PinPanel_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
