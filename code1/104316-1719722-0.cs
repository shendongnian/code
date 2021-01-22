    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddMouseMoveHandler(this);
        }
        private void AddMouseMoveHandler(Control c)
        {
            c.MouseMove += MouseMoveHandler;
            if(c.Controls.Count>0)
            {
                foreach (Control ct in c.Controls)
                    AddMouseMoveHandler(ct);
            }
        }
        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            lblXY.Text = string.Format("X: {0}, Y:{1}", e.X, e.Y);
        }
    }
