    public void BubbleSortImproved<T>(IList<T> list)
    {
        BubbleSortImproved<T>(list, Comparer<T>.Default);
    }
    public void BubbleSortImproved<T>(IList<T> list, IComparer<T> comparer)
    {
        bool stillGoing = true;
        int k = 0;
        while (stillGoing)
        {
            stillGoing = false;
            //reduce the iterations number after each loop
            for (int i = 0; i < list.Count - 1 - k; i++)
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
            k++;
        }
    }
