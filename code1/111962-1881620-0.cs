    public IEnumerable<int> GetRandomSequence(int max)
    {
        var r = new Random();
        while (true)
        {
           yield return r.GetNext(max);
        }
    }
