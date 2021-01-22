        // sample data
        var data = new[] {
            new { Foo = 1, Bar = "Don Smith"},
            new { Foo = 1, Bar = "Mike Jones"},
            new { Foo = 1, Bar = "James Ray"},
            new { Foo = 2, Bar = "Tom Rizzo"},
            new { Foo = 2, Bar = "Alex Homes"},
            new { Foo = 3, Bar = "Andy Bates"},
        };
        // group into columns, and select the rows per column
        var grps = from d in data
                  group d by d.Foo
                  into grp
                  select new {
                      Foo = grp.Key,
                      Bars = grp.Select(d2 => d2.Bar).ToArray()
                  };
        // find the total number of (data) rows
        int rows = grps.Max(grp => grp.Bars.Length);
        // output columns
        foreach (var grp in grps) {
            Console.Write(grp.Foo + "\t");
        }
        Console.WriteLine();
        // output data
        for (int i = 0; i < rows; i++) {
            foreach (var grp in grps) {
                Console.Write((i < grp.Bars.Length ? grp.Bars[i] : null) + "\t");
            }
            Console.WriteLine();
        }
