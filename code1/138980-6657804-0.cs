    class NoSnapWindow : System.Windows.Window
    {
        public NoSnapWindow()
        {
            SourceInitialized += delegate {
                var source = HwndSource.FromVisual(this) as HwndSource;
                source.AddHook(SourceHook);
            };
        }
    
        private IntPtr SourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x112: // WM_SYSCOMMAND
                    switch (wParam.ToIn32() & ~0x0F)
                    {
                        case 0xF010: // SC_MOVE
                            ResizeMode = ResizeMode.NoResize;
                            break;
                    }
                case 0x2A2: // WM_MOUSELEAVE
                    ResizeMode = ResizeMode.CanResize;
            }
        }
    }
