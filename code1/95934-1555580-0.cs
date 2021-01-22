    Console.WriteLine("Starting algorithm...");
    int line = Console.CursorTop;
    for (int i=0;i<100;++i)
    {
        Console.SetCursorPosition(0,line);
        Console.Write("Progress is {0}%        ",i);  // Pad with spaces to make sure we cover old text
        Thread.Sleep(100);
    }
    Console.SetCursorPosition(0,line);    
    Console.WriteLine("Algorithm Complete.       "); // Pad with spaces to make sure we cover old text
