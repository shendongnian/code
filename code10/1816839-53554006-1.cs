            double[] a = { 1, 9, 9, 8, 9, 2, 2 };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == a.Max())
                {
                    Console.WriteLine(i);
                    break;
                }
            }
