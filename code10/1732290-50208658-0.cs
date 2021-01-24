    public static class extensions
    {
        public static void SaveFormSizeAndLocation(this Form form)
        {
            try
            {
                using (RegistryKey key = Application.UserAppDataRegistry.CreateSubKey(form.Name))
                {
                    if (key != null)
                    {
                        if (form.WindowState == FormWindowState.Normal)
                        {
                            key.SetValue("Left", form.Left);
                            key.SetValue("Top", form.Top);
                            key.SetValue("Width", form.Width);
                            key.SetValue("Height", form.Height);
                        }
                        if (form.ShowInTaskbar)
                        {
                            string windowState = Enum.GetName(typeof(FormWindowState), form.WindowState);
                            key.SetValue("WindowState", form.WindowState);
                        }
                    }
                }
            }
            catch
            {
                // Party on, Garth!
            }
        }
        public static void LoadFormSizeAndLocation(this Form form)
        {
            try
            {
                using (RegistryKey key = Application.UserAppDataRegistry.OpenSubKey(form.Name))
                {
                    if (key != null)
                    {
                        form.Left = (int)key.GetValue("Left", form.Left);
                        form.Top = (int)key.GetValue("Top", form.Top);
                        form.Width = (int)key.GetValue("Width", form.Width);
                        form.Height = (int)key.GetValue("Height", form.Height);
                        // Move window into visible screen bounds if outside screen bounds (prevent off-screen hidden windows)
                        Rectangle screenRect = SystemInformation.VirtualScreen;
                        if (form.Left < screenRect.Left)
                            form.Left = screenRect.Left;
                        if (form.Top < screenRect.Top)
                            form.Top = screenRect.Top;
                        if (form.Right > screenRect.Right)
                            form.Left = screenRect.Right - form.Width;
                        if (form.Bottom > screenRect.Bottom)
                            form.Top = screenRect.Bottom - form.Height;
                        if (form.ShowInTaskbar)
                        {
                            string windowState = Enum.GetName(typeof(FormWindowState), form.WindowState);
                            windowState = key.GetValue("WindowState", windowState).ToString();
                            form.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), windowState);
                        }
                    }
                }
            }
            catch
            {
                // Party on, Wayne!
            }
        }
    }
