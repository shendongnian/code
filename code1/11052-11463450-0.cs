        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public Main()
        {
            InitializeComponent();
            Process current = Process.GetCurrentProcess();
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (process.Id != current.Id)
                {
                    try
                    {
                        if (md5hash(current.MainModule.FileName) == md5hash(process.MainModule.FileName))
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            Environment.Exit(0);
                        }
                    }
                    catch (/* your exception */) { /* your exception goes here */ }
                }
            }
        }
        private string md5hash(string file)
        {
            FileStream FileCheck = File.OpenRead(file);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(FileCheck);
            FileCheck.Close();
            string check = BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
            return check;
        }
