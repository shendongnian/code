    // ... or MichaelGG's
    var res = dc.Foos
               .Where(x => x.Bla > 0)  // uses IQueryable provider
               .AsEnumerable()
               .Where(y => y.Snag > 0); // IEnumerable, uses LINQ to Objects
