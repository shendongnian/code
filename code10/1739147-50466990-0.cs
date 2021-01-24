        private void Form1_Load(object sender, EventArgs e)
        {
            ActiveControl = SomeControl;
        }
        private void YourTabControl_Layout(object sender, LayoutEventArgs e)
        {
            if (YourTabControl.SelectedIndex == 0)
                SomeControl.Focus();
        }
