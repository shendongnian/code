            int counter = 0;
            for (int c = 0; c <= 100; c++)
            {
                counter = 0;
                for (int i = 1; i <= c; i++)
                {
                    if (c % i == 0)
                    { counter++; }
                }
                if (counter == 2)
                { Console.Write(c + " "); }
            }
