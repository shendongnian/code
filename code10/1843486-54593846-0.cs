    using System;
    using System.Threading;
    
    public class ServerClass
    {
        // The method that will be called when the thread is started.
        public void HeavyCalculation()
        {
            Console.WriteLine(
                "Heavy Calculation is running on another thread.");
    
            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(3000);
            Console.WriteLine(
                "Heavy Calculation has ended.");
        }
    }
    
    public class App
    {
        public static void Main()
        {
            ServerClass serverObject = new ServerClass();
    
            // Create the thread object, passing in the
            // serverObject.InstanceMethod method using a
            // ThreadStart delegate.
            Thread InstanceCaller = new Thread(
                new ThreadStart(serverObject.HeavyCalculation));
    
            // Start the thread.
            InstanceCaller.Start();
    
            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");
    
        }
    }
  
