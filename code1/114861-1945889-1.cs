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
                this.SuspendLayout();
                this.scrollPosition += (Size)clickPosition - (Size)e.Location;
                this.panel1.AutoScrollPosition = scrollPosition;                    
                this.ResumeLayout(false);
            }
        }
