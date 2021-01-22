            /// <summary>
            /// 0: the window is completely transparent ... 255: the window is opaque
            /// </summary>
            private byte _alpha;
            private enum GetWindowLong
            {
                /// <summary>
                /// Sets a new extended window style.
                /// </summary>
                GWL_EXSTYLE = -20
            }
            private enum ExtendedWindowStyles
            {
                /// <summary>
                /// Transparent window.
                /// </summary>
                WS_EX_TRANSPARENT = 0x20,
                /// <summary>
                /// Layered window. http://msdn.microsoft.com/en-us/library/windows/desktop/ms632599%28v=vs.85%29.aspx#layered
                /// </summary>
                WS_EX_LAYERED = 0x80000
            }
            private enum LayeredWindowAttributes
            {
                /// <summary>
                /// Use bAlpha to determine the opacity of the layered window.
                /// </summary>
                LWA_COLORKEY = 0x1,
                /// <summary>
                /// Use crKey as the transparency color.
                /// </summary>
                LWA_ALPHA = 0x2
            }
            [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
            private static extern int User32_GetWindowLong(IntPtr hWnd, GetWindowLong nIndex);
            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            private static extern int User32_SetWindowLong(IntPtr hWnd, GetWindowLong nIndex, int dwNewLong);
            [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
            private static extern bool User32_SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, LayeredWindowAttributes dwFlags);
            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                //Click through
                int wl = User32_GetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE);
                User32_SetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE, wl | (int)ExtendedWindowStyles.WS_EX_LAYERED | (int)ExtendedWindowStyles.WS_EX_TRANSPARENT);
                //Change alpha
                User32_SetLayeredWindowAttributes(this.Handle, (TransparencyKey.B << 16) + (TransparencyKey.G << 8) + TransparencyKey.R, _alpha, LayeredWindowAttributes.LWA_COLORKEY | LayeredWindowAttributes.LWA_ALPHA);
            }
