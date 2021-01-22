    public class Foo
    {
        public string Bar;
        public string Baz;
        public bool HasDuplicates;
    }
    public static void SetHasDuplicate(IEnumerable<Foo> foos)
    {
        foos
            .SelectMany(f => new[] { new { Foo = f, Str = f.Bar }, new { Foo = f, Str = f.Baz } })
            .Distinct() // Eliminates double entries where Foo.Bar == Foo.Baz
            .GroupBy(x => x.Str)
            .ToList()
            .ForEach(g => g
                .ToList()
                .ForEach(x => x.Foo.HasDuplicates |= g.Count() > 1));
    }
