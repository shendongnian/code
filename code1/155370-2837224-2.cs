        bool lockTaken = false;   
        var temp = test2;
        try {   
            System.Threading.Monitor.Enter(temp, ref lockTaken);   
            test2 = null;   
            Console.WriteLine("Manual collect 3.");   
            GC.Collect();   
            GC.WaitForPendingFinalizers();   
            Console.WriteLine("Manual collect 4.");   
            GC.Collect();   
        }   
        finally {   
           System.Threading.Monitor.Exit(temp);   
        }  
