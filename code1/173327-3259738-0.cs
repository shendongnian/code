    // I haz an array...
    public int ArrayCount(object[] array)
    {
        int count = 0;
        try
        {
            while (true)
            {
                var temp = array[count];
                count++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            return count;
        }
    }
