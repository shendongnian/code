    Merkmalls = Merkmalls
                    .GroupBy(x => new { Name = x.Name, Wert= x.Wert})
                    .Where(g => g.Count() == 1)
                    .Select(g => g.First())
                    .ToList();
