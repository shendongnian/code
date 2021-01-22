    public static void Shuffle<T>(this List<T> source)
    {
        Random rnd = new Random();
        for (int i = 0; i < source.Count; i++)
        {
            int index = rnd.Next(0, source.Count);
            T o = source[0];
            source.RemoveAt(0);
            source.Insert(index, o);
        }
    }
