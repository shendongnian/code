    for (int i = 0; i < 100; i += 2) {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Number 1 - {0}", i);
        Console.WriteLine("Number 2 - {0}", i + 1);
        System.Threading.Thread.Sleep(100);
    }
