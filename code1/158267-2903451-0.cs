    static Random rand = new Random();
    static void Randomize<T>(IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int i2 = rand.Next(i + 1);
            if (i2 != i)
            {
                T tmp = list[i2];
                list[i2] = list[i];
                list[i] = tmp;
            }
        }
    }
