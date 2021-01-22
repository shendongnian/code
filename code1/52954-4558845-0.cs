                // Find z-order for window.
                Process[] procs = Process.GetProcessesByName("notepad");
                Process top = null;
                int topz = int.MaxValue;
                foreach (Process p in procs)
                {
                    IntPtr handle = p.MainWindowHandle;
                    int z = 0;
                    do
                    {
                        z++;
                        handle = GetWindow(handle, 3);
                    } while(handle != IntPtr.Zero);
                    if (z < topz)
                    {
                        top = p;
                        topz = z;
                    }
                }
                if(top != null)
                    Debug.WriteLine(top.MainWindowTitle);
