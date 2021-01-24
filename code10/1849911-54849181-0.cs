        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        private const int SWP_NOSIZE = 0x0001;
        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            bool foundIt = false;
            DateTime timeOut = DateTime.Now.AddSeconds(10);
            Launch();
            do
            {
                await Task.Delay(250);
                var hWnd = FindWindow(null, "dialog.vi");
                if (!hWnd.Equals(IntPtr.Zero))
                {
                    SetParent(hWnd, panel1.Handle);
                    SetWindowPos(hWnd, 0, 0, 0, 0, 0, SWP_NOSIZE);
                    foundIt = true;
                }
            }
            while (!foundIt && (DateTime.Now <= timeOut));
            if (!foundIt)
            {
                MessageBox.Show("Failed to find the LabView window.");
            }
        }
