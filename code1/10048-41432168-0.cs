            int i = 1 + 3;
            // Debug.Assert method in Debug mode fails, since i == 4
            Debug.Assert(i == 3);
            Debug.WriteLine(i == 3, "i is equal to 3");
    
            // Trace.Assert method in Release mode is not failing.
            Trace.Assert(i == 4);
            Trace.WriteLine(i == 4, "i is equla to 4");
    
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
