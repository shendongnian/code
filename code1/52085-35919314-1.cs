        private DateTime mouseMoveTime = DateTime.Now;
        private bool IsHovering()
        {
            return (mouseMoveTime.AddMilliseconds(SystemInformation.MouseHoverTime)).CompareTo(DateTime.Now) < 0;
        }
        private void myControl_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoveTime = DateTime.Now;
        }
