        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                myLine.StartPoint = e.Location;
                this.Refresh();
            }
        }
