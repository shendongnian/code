    class SomeForm : Form
    {
        protected Panel _panel1;
        public Form_Load(object sender, EventArgs e)
        {
            _panel1 = new Panel
            {
                BackColor = Color.Red,
                Location = new Point(0, 0),
                Size = new Size(320, 480)
            };
            this.Controls.Add(panel1);
        }
        public void Example()
        {
            _panel1.BackColor = Color.Blue; //Simple to change it if you have a reference already
        }
    }
