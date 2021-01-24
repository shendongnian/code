    private void label1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
    
                    if (label1.Location.Y > 0 && label1.Location.Y < panel1.Size.Height) // not the most accurate way, but you get the idea
                    {
                        mPointDown = new Point(e.X, e.Y);
                    }
    
    
                }
            }
    
            private void label1_MouseUp(object sender, MouseEventArgs e)
            {
                bool movedUp, movedDown;
    
                if (e.Y == mPointDown.Y)
                {
                    movedUp = movedDown = false;
                }
                else
                {
                    movedUp = e.Y < mPointDown.Y;
                    movedDown = !movedUp;
                }
                if (movedDown)
                {
                    label1.Location = new Point(label1.Location.X, label1.Location.Y + 10);
                }
                else if (movedUp)
                {
                    label1.Location = new Point(label1.Location.X, label1.Location.Y - 10);
                }
            }
    
            private void label1_MouseMove(object sender, MouseEventArgs e)
            {
                mouseDownPoint = e.Location;
            }
