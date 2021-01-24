    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e); // Goes through as a MouseDown Event from UserControl1
        }
    }
