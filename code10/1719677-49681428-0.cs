        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int newX = e.X + pictureBox1.Left - _MouseDownLocation.X;
                int newY = e.Y + pictureBox1.Top - _MouseDownLocation.Y;
                int rightBoundary = ClientSize.Width - pictureBox1.Width;
                int bottomBoundary = ClientSize.Height - pictureBox1.Height - statusStrip1.Height;
                
                if (newX > rightBoundary)
                    newX = rightBoundary;
                else if (newX < 0)
                    newX = 0;
                if (newY > bottomBoundary)
                    newY = bottomBoundary;
                else if (newY < 0)
                    newY = 0;
                pictureBox1_MouseMove.Location = new Point(newX, newY);
            }
        }
