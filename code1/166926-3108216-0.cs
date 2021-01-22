    using System;
    using System.Threading;
    
    namespace Treading
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Main program starts");
                Thread firstThread = new Thread(A);
                ThreadStateMessage messageToA = new ThreadStateMessage(){YouShouldStopNow = false};
                firstThread.Start(messageToA);
                Thread.Sleep(50); //Let other threads do their thing for 0.05 seconds
                Console.WriteLine("Sending stop signal from main program!");
                messageToA.YouShouldStopNow = true;
                firstThread.Join();
                Console.WriteLine("Main program ends - press any key to exit");
                Console.Read();//
            }
    
            private class ThreadStateMessage
            {
                public bool YouShouldStopNow = false; //this assignment is not really needed, since default value is false
            }
    
            public static void A(object param)
            {
                ThreadStateMessage myMessage = (ThreadStateMessage)param;
                Console.WriteLine("Hello from A");
                ThreadStateMessage messageToB = new ThreadStateMessage();
                Thread secondThread = new Thread(B);
                secondThread.Start(messageToB);
    
                while (!myMessage.YouShouldStopNow)
                {
                    Thread.Sleep(10);
                    Console.WriteLine("A is still running");
                }
    
                Console.WriteLine("Sending stop signal from A!");
                messageToB.YouShouldStopNow = true;
                secondThread.Join();
    
                Console.WriteLine("Goodbye from A");
            }
    
            public static void B(object param)
            {
                ThreadStateMessage myMessage = (ThreadStateMessage)param;
                Console.WriteLine("Hello from B");
                while(!myMessage.YouShouldStopNow)
                {
                    Thread.Sleep(10);
                    Console.WriteLine("B is still running");
                }
                Console.WriteLine("Goodbye from B");
            }
        }
    }
