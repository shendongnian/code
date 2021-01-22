    List<List<T>> generatedCombinations = 
        collectionOfSeries.Where(l => l.Any())
                          .Take(1)
                          .DefaultIfEmpty(new List<T>())
                          .First()
                          .Select(i => (new T[]{i}).ToList())                          
                          .ToList();
