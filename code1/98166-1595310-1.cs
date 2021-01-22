    public void BubbleSort<T>(IList<T> list)
    {
        BubbleSort<T>(list, Comparer<T>.Default);
    }
    public void BubbleSort<T>(IList<T> list, IComparer<T> comparer)
    {
        bool stillGoing = true;
        while (stillGoing)
        {
            stillGoing = false;
            for (int i = 0; i < list.Count-1; i++)
            {
                T x = list[i];
                T y = list[i + 1];
                if (comparer.Compare(x, y) > 0)
                {
                    list[i] = y;
                    list[i + 1] = x;
                    stillGoing = true;
                }
            }
        }
    }
