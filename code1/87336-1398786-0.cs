    public partial class Form2 : Form
    {
        private int _x, _y;
    
        public Form2()
        {
            InitializeComponent();
        }
    
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel1.Location = new Point(panel1.Location.X + (e.X - _x), panel1.Location.Y + (e.Y - _y));
                label1.Location = new Point(label1.Location.X + (e.X - _x), label1.Location.Y + (e.Y - _y));
            }
        }
    
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _x = e.X;
                _y = e.Y;
            }
        }
    }
