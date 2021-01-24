    public partial class Form1 : Form
    {
        private Boolean _button1IsRightClicked;
        public Form1()
        {
            InitializeComponent();
            _button1IsRightClicked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= button1.Location.X && e.X <= (button1.Location.X + button1.Width) &&
                e.Y >= button1.Location.Y && e.Y <= (button1.Location.Y + button1.Height))
            {
                _button1IsRightClicked = true;
            }
            else
            {
                _button1IsRightClicked = false;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X >= button1.Location.X && e.X <= (button1.Location.X + button1.Width) &&
                e.Y >= button1.Location.Y && e.Y <= (button1.Location.Y + button1.Height))
            {
                _button1IsRightClicked = false;
                enableDisableButton1(button1.Enabled);
            }
            else
            {
                _button1IsRightClicked = false;
            }
        }
        private void enableDisableButton1(Boolean isEnabled)
        {
            if (isEnabled)
            {
                button1.Enabled = false;
                isEnabled = false;
            }else
            {
                button1.Enabled = true;
                isEnabled = true;
            }
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _button1IsRightClicked = true;
            }
            else
            {
                _button1IsRightClicked = false;
            }
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _button1IsRightClicked == true)
            {
                _button1IsRightClicked = false;
                enableDisableButton1(button1.Enabled);
            }
            else
            {
                _button1IsRightClicked = false;
            }
        }
    }
