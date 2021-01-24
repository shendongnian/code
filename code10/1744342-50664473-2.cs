        [DllImport("user32.dll")]
        public static extern int SetCursor(IntPtr cursor);
        private const int WM_SETCURSOR = 0x20;
        protected override void WndProc(ref System.Windows.Forms.Message m) {
            if (m.Msg == WM_SETCURSOR) {
                SetCursor(Cursors.PanNorth.Handle);
                m.Result = new IntPtr(1);
                return;
            }
            base.WndProc(ref m);
        }
