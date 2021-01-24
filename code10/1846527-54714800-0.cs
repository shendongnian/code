        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.Location = new Point(e.X + button1.Left - MouseDownLocation.X, e.Y + button1.Top - MouseDownLocation.Y);
                Rectangle btnRC = button1.Bounds;
                Rectangle pnlRC = panel1.Bounds;
                // see if the rectangles INTERSECT
                if (pnlRC.IntersectsWith(btnRC))
                {
                    panel1.BackColor = Color.Green;
                }
                else
                {
                    panel1.BackColor = this.BackColor;
                }
                // see if the panel COMPLETELY CONTAINS the button
                if (pnlRC.Contains(btnRC))
                {
                    panel1.BackColor = Color.Green;
                }
                else
                {
                    panel1.BackColor = this.BackColor;
                }
            }
        }
