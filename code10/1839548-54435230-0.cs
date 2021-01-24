    private static object lockObject = new object(); // you need an object of a reference type for locking
    static void Write(char c, int x)
    {
        int yCounter = 0;
        for (int i = 0; i < 1000; i++)
        {
            lock(lockObject)
            {
                Console.SetCursorPosition(x, yCounter);
                Console.Write(c);
            }
            yCounter++;
            Thread.Sleep(100);
        }
    }
