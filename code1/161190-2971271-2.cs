    [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInstertAfter, int x, int y, int cx, int cy, uint flags);
    const int SWP_NOSIZE = 0x0001;
    private void pictureBox4_MouseMove(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0xa1, 0x2, 0);
            SetWindowPos(Handle, IntPtr.Zero, this.Location.X + e.X,
                    this.Location.Y + e.Y, 0, 0, SWP_NOSIZE);
        }
    }
