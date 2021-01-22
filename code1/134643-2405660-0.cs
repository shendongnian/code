    [TestClass]
    public class MyTestClass
    {
        private Process _userAppProcess;
        private AutomationElement _userApplicationElement ;
        /// <summary>
        /// Gets the current directory where the executables are located.  
        /// </summary>
        /// <returns>The current directory of the executables.</returns>
        private static String GetCurrentDirectory()
        {
            return Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).AbsolutePath).Replace("%20", " ");
        }
        [TestInitialize]
        public void SetUp()
        {
            Thread appThread = new Thread(delegate()
            {
                _userAppProcess = new Process();
                _userAppProcess.StartInfo.FileName =GetCurrentDirectory() + "\\UserApplication.exe";
                _userAppProcess.StartInfo.WorkingDirectory = DirectoryUtils.GetCurrentDirectory();
                _userAppProcess.StartInfo.UseShellExecute = false;
                _userAppProcess.Start();
            });
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
            WaitForApplication();
        }
        private void WaitForApplication()
        {
            AutomationElement aeDesktop = AutomationElement.RootElement;
            if (aeDesktop == null)
            {
                throw new Exception("Unable to get Desktop");
            }
            _userApplicationElement = null;
            do
            {
                _userApplicationElement = aeDesktop.FindFirst(TreeScope.Children,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "UserApplicationWindow"));
                Thread.Sleep(200);
            } while ( (_userApplicationElement == null || _userApplicationElement.Current.IsOffscreen) );
        }
        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                // Tell the application's main window to close.
                WindowPattern window = _userApplicationElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern ;
                window.Close();
                if (!_userAppProcess.WaitForExit(3000))
                {
                    // We waited 3 seconds for the User Application to close on its own.  
                    // Send a close request again through the process class.
                    _userAppProcess.CloseMainWindow();
                }
               
                // All done trying to close the window, terminate the process
                _userAppProcess.Close();
                _userAppProcess = null; 
            }
            catch (Exception ex)
            {
                // I know this is bad, but catching the world is better than letting it fail.
            }
        }
    }
