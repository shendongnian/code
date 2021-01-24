    List<UserRank> userRanks = new List<UserRank>();
    for(int i=0;i<Users.Count;i++)
    {
        for(int j=i;j<Users.Count;j++)
        {
            userRanks.Add(new UserRank
            {
                UserA = Users[i],
                UserB = Users[j]
            });
        }
    }
        
    var groups = userRanks.GroupBy(u => u.Compare, u => u).OrderByDescending(g => g.Key);
        
    foreach(var group in groups)
    {
        Console.WriteLine("{0} in common:",group.Key);
        
        foreach(var u in group)
        {
            Console.WriteLine("  {0}-{1}",u.UserA.ID,u.UserB.ID);
        }
    }
