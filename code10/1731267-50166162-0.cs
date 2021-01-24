    private void Simulate()
    {
        while (Winner == null)
        {
            var winnerId = Players[RndGen.Get(0, Players.Count)].Id;
            var loserPoints = RndGen.Get(0, 5);
                Players.Find(p => p.Id == winnerId).SetPoints.Add(6);
                Players.Find(p => p.Id != winnerId).SetPoints.Add(loserPoints);
        }
        Console.WriteLine(Winner.Id);
        Players.ForEach(p => p.SetPoints = new List<int>());
    }
