    public static void Main()
    {
        var DestrezzaGiocatore1 = 5;
        var DestrezzaGiocatore2 = 1;
        var DestrezzaGiocatore3 = 6;
    
        List<PlayerStats> playerStats = new List<PlayerStats>()
        {
            new PlayerStats() { PlayerId = "1", Dexterity = DestrezzaGiocatore1 },
            new PlayerStats() { PlayerId = "2", Dexterity = DestrezzaGiocatore2 },
            new PlayerStats() { PlayerId = "3", Dexterity = DestrezzaGiocatore3 }
        };
    
        var statsSorted = playerStats.OrderByDescending(a => a.Dexterity);    
        Console.WriteLine($"Player {statsSorted.First()} has the highest dexterity: {statsSorted.First().Dexterity}");
        foreach (var playerStat in statsSorted)
        {
            Console.WriteLine($"Player {playerStat.PlayerId}: {playerStat.Dexterity}");
        }
    
        Console.ReadKey();
    }
    
