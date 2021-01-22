            private void listBox3_MouseEnter(object sender, EventArgs e)
        {
            button1.Visible = true;
            visibleTimer.Stop();
            visibleTimer.Start();
        }
        void visibleTimer_Tick(object sender, EventArgs e)
        {
            if (!new Rectangle(new Point(0, 0), listBox3.Size).Contains(listBox3.PointToClient(Control.MousePosition)))
            {
                visibleTimer.Stop();
                button1.Visible = false;
            }
        }
