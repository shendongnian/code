            #region Suspend
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
            private const int WM_SETREDRAW = 11;
            public static IDisposable BeginSuspendlock(this Control ctrl)
            {
                return new suspender(ctrl);
            }
            private class suspender : IDisposable
            {
                private Control _ctrl;
                public suspender(Control ctrl)
                {
                    this._ctrl = ctrl;
                    SendMessage(this._ctrl.Handle, WM_SETREDRAW, false, 0);
                }
                public void Dispose()
                {
                    SendMessage(this._ctrl.Handle, WM_SETREDRAW, true, 0);
                    this._ctrl.Refresh();
                }
            }
            #endregion
