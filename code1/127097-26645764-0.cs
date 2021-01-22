        [DllImport("User32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            SetForegroundWindow(new HandleRef(this, this.Handle));
            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;
             x = x - 10;
            y = y - 40;
            this.contextMenuStrip1.Show(x,y );
            //this.PointToClient(Cursor.Position)
        }
