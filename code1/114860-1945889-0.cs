        protected Point clickPosition;
        protected Point scrollPosition;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.clickPosition = e.Location;            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.panel1.AutoScrollPosition =
                    scrollPosition + (Size)clickPosition - (Size)e.Location;
            }
        }
