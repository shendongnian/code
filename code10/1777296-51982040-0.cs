        foreach (var item in lista.Where(x => x.Deleted == 1).GroupBy(x => x.Id).Select(g => {g.First().MyProperty = string.Join(",", lista.Where(t => t.Id == g.First().Id).Select(x => x.MyProperty).ToArray()); return g.First();}))
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.MyProperty);
        }
