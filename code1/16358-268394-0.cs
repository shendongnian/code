    public static class ProcessExtensions
    {
        public static bool IsRunning(this Process process)
        {
            if (process == null) 
                throw new ArgumentNullException("process");
            try
            {
                Process.GetProcessById(process.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
    }
