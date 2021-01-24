    int[] a = new int[10]{ 46, 47, 29, 50, 71, 20, 64, 90, 44, 16 };
                int asd;
    
                for (int i = 0; i <= a.Length - 1; i++)
                {
                    asd = a[i] / 10;
                    Console.WriteLine(new string('p', 10-asd)+new string('*',asd));
                }
