    using System.Linq;                // provides the Where() extension method
    Random rnd = new Random();
    var opponents = new List<Player> { p2, p3 };  // add more as needed
    while (true)
    {
        opponents.RemoveAll(x => !x.Alive);  // only keep live enemies (efficient: does not create new List)
        if (opponents.Count == 0)            // if nobody left --> exit loop
            break;
        int victim = rnd.Next(0, opponents.Count);
        p1.Attack(opponents[victim]);
        Thread.Sleep(2000);
    }
