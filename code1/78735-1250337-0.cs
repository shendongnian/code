        private void AddHandles()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.MouseEnter += new EventHandler(ButtonEnter);
                    c.MouseLeave += new EventHandler(ButtonLeave);
                    c.MouseDown += new MouseEventHandler(ButtonDown);
                    c.MouseUp += new MouseEventHandler(ButtonUp);
                }
            }
        }
        private void ButtonEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.DarkGray;
            ((Button)sender).Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void ButtonLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void ButtonDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackColor = Color.Gray;
        }
        private void ButtonUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).Cursor = System.Windows.Forms.Cursors.Default;
            
            //Code to be executed 
            //Use the name/text/etc of the Button to figure what to do...
        }
