                if (m.Msg == User32.WM_WINDOWPOSCHANGING && IsHandleCreated)
                {
                    User32.WINDOWPLACEMENT wp = new User32.WINDOWPLACEMENT();
                    wp.length = Marshal.SizeOf(typeof(User32.WINDOWPLACEMENT));
                    User32.GetWindowPlacement(Handle, ref wp);
                    switch (wp.showCmd)
                    {
                        case User32.SW_RESTORE:
                        case User32.SW_NORMAL:
                        case User32.SW_SHOW:
                        case User32.SW_SHOWNA:
                        case User32.SW_SHOWNOACTIVATE:
                            _windState = FormWindowState.Normal;
                            if (wp.showCmd == User32.SW_RESTORE)
                                Update();
                            break;
                        case User32.SW_SHOWMAXIMIZED:
                            _windState = FormWindowState.Maximized;
                            SetMaximumSize();
                            break;
                        case User32.SW_SHOWMINIMIZED:
                        case User32.SW_MINIMIZE:
                        case User32.SW_SHOWMINNOACTIVE:
                            _windState = FormWindowState.Minimized;
                            break;
                    }
                }
        private void SetMaximumSize()
        {
            Screen screen = Screen.FromControl(this);
            if (screen != null && !screen.WorkingArea.IsEmpty)
            {
                int sizeDiff = this.Size.Width - this.ClientSize.Width;
                var maxSize = new Size(screen.WorkingArea.Width + sizeDiff, screen.WorkingArea.Height + sizeDiff);
                this.MaximumSize = maxSize;
            }
        }
        #region Window State
        public const int SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9;
        #endregion Window State
