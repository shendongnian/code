        private void buttonLeft_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(-panel1.AutoScrollPosition.X - 200);
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(-panel1.AutoScrollPosition.X + 200);
        }
