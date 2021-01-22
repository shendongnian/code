        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        
        internal void Move(int deltaX, int deltaY)
        {
            if (mIsMoving)
            {
                return;
            }
            mIsMoving = true;
            try
            {
                if (Child == null)
                    return;
                var hwndSource = (PresentationSource.FromVisual(Child)) as HwndSource;
                if (hwndSource == null)
                    return;
                var hwnd = hwndSource.Handle;
                RECT rect;
                if (!GetWindowRect(hwnd, out rect))
                    return;
                MoveWindow(hwnd, rect.Left + deltaX, rect.Top + deltaY, (int)Width, (int)Height, true);
            }
            finally
            {
                mIsMoving = false;
            }
        }
