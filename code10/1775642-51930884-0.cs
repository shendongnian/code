    private static void testIfs()
    {
        int count = 100000;
        
        {
            Stopwatch w = Stopwatch.StartNew();
            int test = 0;
            bool isActive = true;
            bool isResponding = false;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive && isResponding)
                        test++;
            test = 0;
            isActive = false;
            isResponding = true;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive && isResponding)
                        test++;
            w.Stop();
            Console.WriteLine("using &&: " + w.ElapsedTicks);
        }
        {
            Stopwatch w = Stopwatch.StartNew();
            int test = 0;
            bool isActive = true;
            bool isResponding = false;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive)
                        if (isResponding)
                            test++;
            test = 0;
            isActive = false;
            isResponding = true;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive)
                        if (isResponding)
                            test++;
            w.Stop();
            Console.WriteLine("using 2 ifs: " + w.ElapsedTicks);
        }
        {
            Stopwatch w = Stopwatch.StartNew();
            int test = 0;
            bool isActive = true;
            bool isResponding = false;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive || isResponding)
                        test++;
            test = 0;
            isActive = false;
            isResponding = true;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive || isResponding)
                        test++;
            w.Stop();
            Console.WriteLine("using ||: " + w.ElapsedTicks);
        }
        {
            Stopwatch w = Stopwatch.StartNew();
            int test = 0;
            bool isActive = true;
            bool isResponding = false;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive)
                        test++;
                    else if (isResponding)
                        test++;
            test = 0;
            isActive = false;
            isResponding = true;
            for (int j = 0; j < count; j++)
                for (int i = 0; i < count; i++)
                    if (isActive)
                        test++;
                    else if (isResponding)
                        test++;
            w.Stop();
            Console.WriteLine("using else if: " + w.ElapsedTicks);
        }
    }
