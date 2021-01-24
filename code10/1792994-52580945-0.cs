     private Point Mouselocation;
    
    
        private void grip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Mouselocation = e.Location;
            }
        }
    
        private void grip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                grip.Left = e.X + grip.Left - Mouselocation.X;
                grip.Top = e.Y + grip.Top - Mouselocation.Y;
            }
        }
