    public class Program
    {
        static void Main()
        {
            var waitHandle = new AutoResetEvent(false);
            ThreadPool.RegisterWaitForSingleObject(
                waitHandle, 
                // Method to execute
                (state, timeout) => 
                {
                    Console.WriteLine("Hello World");
                }, 
                // optional state object to pass to the method
                null, 
                // Execute the method after 2 seconds
                TimeSpan.FromSeconds(2), 
                // Execute the method only once. You can set this to false 
                // to execute it repeatedly every 2 seconds
                true);
            Console.ReadLine();
        }
    }
