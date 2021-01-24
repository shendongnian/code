        static System.Windows.Point pre = new System.Windows.Point();
        static System.Windows.Point cur = new System.Windows.Point();
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                cur = e.GetPosition(panel2);
                bool mouseMoved = (pre != cur);
                if (mouseMoved)
                    direction = MouseMovement.GetMouseDirection(pre, cur);
                pre = cur;
            }
            else
                pre = e.GetPosition(panel2);
        }
