    List<Monster> listA = new List<Monster>();
    
    listA.Add(new Monster(0, "snails", 600));
    listA.Add(new Monster(1, "slimes", 300));
    
    List<Monster> listB = new List<Monster>();
    listB.Add(new Monster(0, "snails", 72));
    
    List<Monster> listC = new List<Monster>();
    listC.Add(new Monster(0, "snails", 300));
    listC.Add(new Monster(1, "slimes", 371));
    listC.Add(new Monster(10, "trolls", 152));
    
    var reuslt =  listA
    		.Union(listB)
    		.Union(listC)
    		.GroupBy(x => new { x.Index ,x.Name })
    		.Select(x=> new Monster(x.Key.Index,x.Key.Name,x.Sum(z=>z.Count)));
