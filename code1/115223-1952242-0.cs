    static List<List<int>> comb;
            static bool []used;
            static void GetCombinationSample()
            {
                int[] arr = { 10, 50, 3, 1, 2 };
                used = new bool[arr.Length];
                used.Fill(false);
                comb = new List<List<int>>();
                List<int> c = new List<int>();
                GetComb(arr, 0, c);
                foreach (var item in comb)
                {
                    foreach (var x in item)
                    {
                        Console.Write(x + ",");
                    }
                    Console.WriteLine("");
                }
            }
            static void GetComb(int[] arr, int colindex, List<int> c)
            {
    
                if (colindex >= arr.Length)
                {
                    comb.Add(new List<int>(c));
                    return;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        c.Add(arr[i]);
                        GetComb(arr, colindex + 1, c);
                        c.RemoveAt(c.Count - 1);
                        used[i] = false;
                    }
                }
            }
