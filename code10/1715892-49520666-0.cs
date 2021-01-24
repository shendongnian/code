    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            Cursor.Position = CenterPoint(panel2);
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            Cursor.Position = CenterPoint(panel1);
        }
        private Point CenterPoint(Control control)
        {
            return new Point(
                Left + control.Left + control.Width / 2, 
                Top + control.Top + control.Height / 2);
        }
    }
