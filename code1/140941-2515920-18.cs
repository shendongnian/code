    IEnumerable<int> GetComputation(int maxIndex)
    {
        var result = new int[maxIndex];
        for(int i = 0; i <= maxIndex; i++)
        {
            result[i] = Computation(i);
        }
        return result;
    }
