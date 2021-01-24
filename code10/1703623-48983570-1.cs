    void Main(string[] args)
    {
        try
        {
            throw new Exception("This is an error\n");
        }
        catch (Exception ex)
        {
            LogError.ToFile(ex);
        }
        LogError.WaitForCompletion();
        //need code here to wait for background processes to finish before ending
    }
    public class LogError
    {
        private static Task _tasks = new List<Task>();
        static public void ToFile(Exception excep)
        {
            _tasks.add(Task.Run(() => LogErrorToFile(excep)));
        }
        static public async Task LogErrorToFile(Exception excep)
        {
            //writes to file using await
        }
        public static void WaitForCompletion() {
            Task.WaitAll(_tasks);
        }
    }
