        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle,
        IntPtr childAfter, string className, IntPtr windowTitle);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd,
            int msg, int wParam, StringBuilder ClassName);
        private static string GetURL(IntPtr intPtr, string programName, out string url)
        {
            string temp=null;
            if (programName.Equals("chrome"))
            {
                var hAddressBox = FindWindowEx(intPtr, IntPtr.Zero, "Chrome_OmniboxView", IntPtr.Zero);
                var sb = new StringBuilder(256);
                SendMessage(hAddressBox, 0x000D, (IntPtr)256, sb);
                temp = sb.ToString();
            } 
            if (programName.Equals("iexplore"))
            {
                foreach (InternetExplorer ie in new ShellWindows())
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ie.FullName);
                    if (fileNameWithoutExtension != null)
                    {
                        var filename = fileNameWithoutExtension.ToLower();
                        if (filename.Equals("iexplore"))
                        {
                            temp+=ie.LocationURL + " ";
                        }
                    }
                }
            }
            if (programName.Equals("firefox"))
           {
                DdeClient dde = new DdeClient("Firefox", "WWW_GetWindowInfo");
                dde.Connect();
                string url1 = dde.Request("URL", int.MaxValue);
                dde.Disconnect();
                temp = url1.Replace("\"","").Replace("\0","");
            }
            url = temp;
            return temp;
        }
