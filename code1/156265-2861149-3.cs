        protected static void Bar(out int[] x)
        {
            var y = new int[100];
            for (int i = 0; i != 100; ++i)
            {
                Thread.Sleep(5);
                y[i] = 1;
            }
            x = y;
        }
