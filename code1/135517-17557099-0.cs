        private bool IsService(string name)
        {
            if (!Environment.UserInteractive) return true;
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController(name);
            try
            {
                return sc.Status == System.ServiceProcess.ServiceControllerStatus.StartPending;
            }
            catch(InvalidOperationException)
            {
                return false;
            }
        }
