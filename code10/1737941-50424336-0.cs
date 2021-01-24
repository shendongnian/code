    public static class Extensions {
            public static void InsertElementDescending(this List<int> source, 
                    int element)
            {
                int index = source.FindLastIndex(e => e > element);
                if (index == 0 || index == -1)
                {
                    source.Insert(0, element);
                    return;
                }
                source.Insert(index + 1, element);
            }
    }
