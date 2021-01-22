    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
            AttachMouseEnterToChildControls(this);
        }
        void AttachMouseEnterToChildControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                c.MouseEnter += new EventHandler(control_MouseEnter);
                c.MouseLeave += new EventHandler(control_MouseLeave);
                AttachMouseEnterToChildControls(c);
            }
        }
        private void control_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }
        private void control_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }
    }
