    User mostTrueUser = Users
            .OrderByDescending(u => (u.A?1:0) + (u.B?1:0) + (u.C?1:0) + (u.D?1:0) + (u.E?1:0))
            .First();
            
    var groups = Users.GroupBy(u => ((u.A && mostTrueUser.A)?1:0)
                                   +((u.B && mostTrueUser.B)?1:0)
                                   +((u.C && mostTrueUser.C)?1:0)
                                   +((u.D && mostTrueUser.D)?1:0)
                                   +((u.E && mostTrueUser.E)?1:0)
                              ,u => u).OrderByDescending(g => g.Key);
    foreach(var group in groups)
    {
        Console.WriteLine("{0}  // following have {0} 'true' in common with {1}",
                          group.Key,
                          mostTrueUser.ID);
        foreach(var g in group)
        {
            Console.WriteLine("  " + g.ID);
        }
    }
