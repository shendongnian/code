    List<Monster> listA = new List<Monster>();
    List<Monster> listB = new List<Monster>();
    List<Monster> listC = new List<Monster>();
    listA.Union(listB).Union(listC)
                .GroupBy(x => new { x.Index ,x.Name }).Select(x=> new {
                    Index = x.Key.Index,
                    Name = x.Key.Name,
                    count = x.Sum(z=>z.Count)}
                );
