    public IEnumerable<string> GetGroup(int size)
    {
        Shuffle(boys);
        Shuffle(girls);
        if((boys.Count + girls.Count) < size)
        {
                throw new ArgumentException("Not enough people to satisfy group");
        }
        bool isBoy = rng.NextDouble() > 0.5;
        for(var i = 0;i<size;i++)
        {
            string next = "";
            if(isBoy)
            {
                yield return PopBoy();
            }
            else
            {
                yield return PopGirl();
            }
            isBoy = !isBoy;
        }
    }
