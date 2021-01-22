        bool FlagEntered;
        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((sender as TextBox).SelectedText == "" && !FlagEntered)
            {
                (sender as TextBox).SelectAll();
                FlagEntered = true;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            FlagEntered = false;
        }
        
