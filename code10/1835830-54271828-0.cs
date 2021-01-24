    public void ShortenArray()
    {
        int[] getallen = new int[] { 1 , 1 , 2 , 2 , 3 , 4 , 4 , 4 , 5 , 6 };
        getallen = getallen.ToList().Distinct().ToArray();
    }
