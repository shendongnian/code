    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
    
            t.Start("My Parameter");
        }
    
        static void ThreadMethod(object parameter)
        {
            // parameter equals to "My Parameter"
        }
    }
