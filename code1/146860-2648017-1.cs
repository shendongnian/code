        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        ProcessWindowStyle state = ProcessWindowStyle.Normal;
        void toggle()
        {
            if (cvarDataServiceProcess.HasExited)
            {
                MessageBox.Show("terminated");
            }
            else
            {
                if (state == ProcessWindowStyle.Hidden)
                {
                    //normal
                    state = ProcessWindowStyle.Normal;
                    ShowWindow(cvarDataServiceProcess.MainWindowHandle, 1);
                }
                else if (state == ProcessWindowStyle.Normal)
                {
                    //hidden
                    state = ProcessWindowStyle.Hidden;
                    ShowWindow(cvarDataServiceProcess.MainWindowHandle, 0);
                }
            }
        }
