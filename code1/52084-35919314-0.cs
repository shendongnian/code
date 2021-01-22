        private DateTime mouseMoveTime = DateTime.Now;
        private Point mouseMoveLoc = new Point();
        private bool IsHovering()
        {
            return (mouseMoveTime.AddMilliseconds(SystemInformation.MouseHoverTime)).CompareTo(DateTime.Now) < 0;
        }
        private void myControl_MouseMove(object sender, MouseEventArgs e)
        {
            // update mouse position and time of last move
            if (Math.Abs(e.X - mouseMoveLoc.X) > SystemInformation.MouseHoverSize.Width || 
                Math.Abs(e.Y - mouseMoveLoc.Y) > SystemInformation.MouseHoverSize.Height)
            {
                mouseMoveLoc = new Point(e.X, e.Y);
                mouseMoveTime = DateTime.Now;
            }
        }
