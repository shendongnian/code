    List<ScenarioResults> a = new List<ScenarioResults> { new ScenarioResults { ProductSubType = "1", SubBook = "1", ScenarioValue = 10}, new ScenarioResults { ProductSubType = "2", SubBook = "2", ScenarioValue = 10 } };
    List<ScenarioResults> b = new List<ScenarioResults> { new ScenarioResults { ProductSubType = "2", SubBook = "2", ScenarioValue = 10 }, new ScenarioResults { ProductSubType = "3", SubBook = "3", ScenarioValue = 10 } };
    List<ScenarioResults> result = a.Concat(b.Select(_ => new ScenarioResults { ProductSubType = _.ProductSubType, SubBook = _.SubBook, ScenarioValue = -_.ScenarioValue ?? null }))
        .GroupBy(x => new {x.ProductSubType, x.SubBook})                  
        .SelectMany(g => g.Select(_ => new ScenarioResults { ProductSubType = _.ProductSubType, SubBook = _.SubBook, ScenarioValue = g.First().ScenarioValue + g.Skip(1).Sum(v => v.ScenarioValue)}))
        .Distinct(new EqualityComparer())
        .ToList();
