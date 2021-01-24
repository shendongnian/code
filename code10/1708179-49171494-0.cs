    public class Program
            {
              
                    static void Main(string[] args)
                    {
                    Console.WriteLine("Please enter any value");
                    string str = Console.ReadLine();
                    ThreadStart childref = new ThreadStart(CallToChildThread);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                    Console.ReadLine();
                }
                public static void CallToChildThread()
                {
                    Console.WriteLine("Child thread starts");
        
                    // the thread is paused for 5000 milliseconds
                    int sleepfor = 5000;
        
                    Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
                    Thread.Sleep(sleepfor);
                    Console.WriteLine("Child thread resumes");
                }
        }
