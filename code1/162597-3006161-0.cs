        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.Text = "in";
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!new Rectangle(new Point(0, 0), panel1.Size).Contains(panel1.PointToClient(Control.MousePosition)))
                this.Text = "out";
        }
