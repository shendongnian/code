    /// <summary>
    /// Picks random selection of available game ID's
    /// </summary>
    private static List<int> GetRandomGameIDs(int count)
    {
        var r = new List<int>();
        var rnd = new Random();
        var gameIDs = (int[])HttpContext.Current.Application["NonDeletedArcadeGameIDs"];
        var totalGameIDs = gameIDs.Count();
        if (count > totalGameIDs) count = totalGameIDs;
        var leftToPick = count;
        var itemsLeft = totalGameIDs;
        var arrPickIndex = 0;
        while (leftToPick > 0)
        {
            if (rnd.Next(0, itemsLeft) < leftToPick)
            {
                r.Add(gameIDs[arrPickIndex]);
                leftToPick--;
            }
            arrPickIndex++;
            itemsLeft--;
        }
        return r;
    }
