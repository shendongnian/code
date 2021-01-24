        private void ButtonSet_Click(object sender, EventArgs e)
        {                    
            Point p = getXYfromTextBox();
            Rectangle circle = new Rectangle(p.X - 8, p.Y - 8, 16, 16);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawEllipse(redPen, circle);
        }
        //this method can be optimized
        private Point getXYfromTextBox()
        {
            string xy = textBox2.Text.Trim();
            string[] xys = xy.Split(';');
            mouseX = Convert.ToInt32(xys[0].Split('=')[1].Trim());
            mouseY = Convert.ToInt32(xys[1].Split('=')[1].Trim());
            Point p = new Point(mouseX, mouseY);
            return p;
        }
