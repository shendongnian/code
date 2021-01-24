    public static int CountMax(this IEnumerable<int> source)
    {
        if (source == null)
        {
            throw new ArgumentException();
        }
        int value = 0;
        bool hasValue = false;
        int count = 0;
        foreach (int x in source)
        {
            if (hasValue)
            {
                if (x > value)
                {
                    value = x;
                    count = 1;
                }
                else if (x == value)
                {
                    count++;
                }
            }
            else
            {
                value = x;
                count = 1;
                hasValue = true;
            }
        }
        if (hasValue)
        {
            return count;
        }
        throw new Exception("no elements");
    }
