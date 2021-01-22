        public void CopyFromScreen(int sourceX, int sourceY, int destinationX, 
                                   int destinationY, Size blockRegionSize, 
                                   CopyPixelOperation copyPixelOperation)
        {
            IntPtr desktopHwnd = GetDesktopWindow();
            if (desktopHwnd == IntPtr.Zero)
            {
                throw new System.ComponentModel.Win32Exception();
            }
            IntPtr desktopDC = GetWindowDC(desktopHwnd);
            if (desktopDC == IntPtr.Zero)
            {
                throw new System.ComponentModel.Win32Exception();
            }
            if (!BitBlt(hDC, destinationX, destinationY, blockRegionSize.Width, 
                 blockRegionSize.Height, desktopDC, sourceX, sourceY, 
                 copyPixelOperation))
            {
                throw new System.ComponentModel.Win32Exception();
            }
            ReleaseDC(desktopHwnd, desktopDC);
        }
