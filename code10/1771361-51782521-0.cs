    while (true)
    {
        for (int i = Int32.MaxValue; i > 0; i--)
        {
            for (int j = 0; j < rng.Next(); j++)
            {
                ThreadHandle.WaitOne();
                // ...
            }
    
            if (i % 500 == 0)
                Console.WriteLine("This engine is working hard!!!");
        }
    }
