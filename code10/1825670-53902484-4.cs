        private void buttonLeft_Click(object sender, EventArgs e)
        {
            Point p = panel1.AutoScrollPosition;
            panel1.AutoScrollPosition = new Point(-p.X - 200)
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            Point p = panel1.AutoScrollPosition;
            panel1.AutoScrollPosition = new Point(-p.X + 200)
        }
