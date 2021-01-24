     bool bIsEnterKeyPressed = false;
     private void frmSampleJson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bIsEnterKeyPressed = true;
            }
            if (!bIsEnterKeyPressed)
            {
                int x = pictureBox1.Location.X;
                int y = pictureBox1.Location.Y;
                {
                    if (e.KeyCode == Keys.Right) x += 50;
                    else if (e.KeyCode == Keys.Left) x -= 50;
                    else if (e.KeyCode == Keys.Up) y -= 50;
                    else if (e.KeyCode == Keys.Down) y += 50;
                    pictureBox1.Location = new Point(x, y);
                }
            }
        }
