        private void Window_Activated(object sender, EventArgs e)
        {
            if (Application.Current.Windows.Count > 1)
            {
                foreach (Window win in Application.Current.Windows)
                    try
                    {
                        if (!win.Equals(this))
                        {
                            if (!win.IsVisible)
                            {
                                win.ShowDialog();
                            }
                            if (win.WindowState == WindowState.Minimized)
                            {
                                win.WindowState = WindowState.Normal;
                            }
                            win.Activate();
                            win.Topmost = true;
                            win.Topmost = false;
                            win.Focus();
                        }
                    }
                    catch { }
            }
            else
                this.Focus();
        }
