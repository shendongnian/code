        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point oldPos = myLine.StartPoint;
                myLine.StartPoint = e.Location;
                this.Invalidate(new Recangle(oldPos.X, oldPos.Y, myLine.Width, myLine.Height));
            }
        }
