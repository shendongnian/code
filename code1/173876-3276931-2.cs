    public static IEnumerable<int> GetList(int upperBound) 
    {
        int i = 0;
        while (i < upperBound)
        {
            i++;
            yield return i;
        }
    }
