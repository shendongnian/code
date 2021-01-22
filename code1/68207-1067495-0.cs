    var simpsons = new[]
                   {
                       new {Name = "Homer", Age = 37},
                       new {Name = "Bart", Age = 10},
                       new {Name = "Marge", Age = 36},
                       new {Name = "Grandpa", Age = int.MaxValue},
                       new {Name = "Lisa", Age = 8}
                   }
                   .ToList();
    simpsons.Sort((a, b) => a.Age - b.Age);
