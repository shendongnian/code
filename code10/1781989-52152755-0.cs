    static Random _random = new Random();
    static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
    public static void Main()
    {
            string[] array = { "tip 1", "tip 2", "tip 3" };
            Shuffle(array);
            foreach (string value in array)
            {
                Console.WriteLine(value);
            }
    }
