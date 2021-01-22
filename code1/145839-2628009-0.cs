    internal class MyTextBox : System.Windows.Forms.TextBox
    {
        public MyTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
