        protected Point clickPosition;
        protected Point scrollPosition;	
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.clickPosition.X = e.X;
            this.clickPosition.Y = e.Y;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scrollPosition.X = scrollPosition.X + clickPosition.X - e.X;
                scrollPosition.Y = scrollPosition.Y + clickPosition.Y - e.Y;
                this.panel.AutoScrollPosition = scrollPosition;
            }
        }  
