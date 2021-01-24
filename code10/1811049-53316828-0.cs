    // mouse is not down
    private void label1_MouseUp(object sender, MouseEventArgs e)
    {
        IsMouseDown = false;
    }
     //mouse is down and set the starting postion
     private void label1_MouseDown(object sender, MouseEventArgs e)
     {   
         //if left mouse button was pressed
         if (e.Button == System.Windows.Forms.MouseButtons.Left)
         {
             IsMouseDown = true;
             label1.BringToFront();
             StartPoint = e.Location;
          }
       }
        //check the label is withing the borders of the picture box
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                int left = e.X + label1.Left - StartPoint.X;
                int right = e.X + label1.Right - StartPoint.X;
                int top = e.Y + label1.Top - StartPoint.Y;
                int bottom = e.Y + label1.Bottom - StartPoint.Y;
                if (left > pictureBox1.Left && top > pictureBox1.Top && pictureBox1.Bottom >= bottom && pictureBox1.Right >= right)
                {
                    label1.Left = left;
                    label1.Top = top;
                }
            }
        }
   
