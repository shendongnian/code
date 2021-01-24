     private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int panLoc = panel1.Location.X;
                int moveLeftRight = e.X + pictureBox1.Left - MouseDownLocation.X;
                int moveUpDown = e.Y + pictureBox1.Top - MouseDownLocation.Y;
                int panlTopLocation = panel1.Location.Y;
                int panlbottomLocation = panel1.Location.Y + panel1.Height - pictureBox1.Height;
                int panlLeftLocation = panel1.Location.X;
                int panlRightLocation = panel1.Location.X + panel1.Width - pictureBox1.Width ;
                if (panlLeftLocation < moveLeftRight)
                {
                    if (panlRightLocation > moveLeftRight)
                    {
                        pictureBox1.Left = moveLeftRight;
                    }
                    else
                    {
                        pictureBox1.Left = panlRightLocation;
                    }
                }
                else
                {
                    pictureBox1.Left = panlLeftLocation;
                }
                if (panlTopLocation < moveUpDown)
                {
                    if (panlbottomLocation > moveUpDown)
                    {
                        pictureBox1.Top = moveUpDown;
                    }
                    else
                    {
                        pictureBox1.Top = panlbottomLocation;
                    }
                }
                else
                {
                    pictureBox1.Top = panlTopLocation;
                }
            }
        }
