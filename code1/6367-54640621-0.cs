    static void Main()
    {
        // Under Windows this is:
        //      C:\Users\SomeUser\AppData\Local\Temp\ 
        // Linux this is:
        //      /tmp/
        var temporaryDirectory = Path.GetTempPath();
        // Application ID (Make sure this guid is different accross your different applications!
        var applicationGuid = "99b8a385-171c-40eb-bdaf-aec170ced98c";
        // file that will serve as our lock
        var fileFulePath = System.IO.Path.Combine(temporaryDirectory, applicationGuid);
        try
        {
            new FileStream(fileFulePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
            // Prevents other processes from reading from or writing to this file
            .Lock(0, 0);
        }
        catch
        {
            Console.WriteLine("Another instance is running. Terminating application.");
            Environment.Exit(1); // terminate application
            return;
        }
        //  Perform your work in here
        Console.WriteLine();
        Console.WriteLine("Doing work...");
        Thread.Sleep(10000);
    } 
