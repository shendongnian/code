    public class Foo
    {
        public string Bar;
        public string Baz;
        public bool HasDuplicates;
    }
    public static void SetHasDuplicate(IEnumerable<Foo> foos)
    {
        var dupes = foos
            .SelectMany(f => new[] { new { Foo = f, Str = f.Bar }, new { Foo = f, Str = f.Baz } })
            .Distinct() // Eliminates double entries where Foo.Bar == Foo.Baz
            .GroupBy(x => x.Str)
            .Where(g => g.Count() > 1)
            .SelectMany(g => g.Select(x => x.Foo))
            .Distinct()
            .ToList();
        dupes.ForEach(d => d.HasDuplicates = true);    
    }
