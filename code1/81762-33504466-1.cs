                bool attached = false;
                // Get uppermost window process
                IntPtr ptr = NativeMethods.GetForegroundWindow();
                int u;
                NativeMethods.GetWindowThreadProcessId(ptr, out u);
                Process process = Process.GetProcessById(u);
                if (string.Compare(process.ProcessName, "cmd", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    // attach to the current active console
                    NativeMethods.AttachConsole(process.Id);
                    attached = true;
                }
                else
                {
                    // create new console
                    NativeMethods.AllocConsole();
                }
                Console.Write("your output");
                NativeMethods.FreeConsole();
                if (attached)
                {
                    var hWnd = process.MainWindowHandle;
                    NativeMethods.PostMessage(hWnd, NativeMethods.WM_KEYDOWN, NativeMethods.VK_RETURN, 0);
                }
