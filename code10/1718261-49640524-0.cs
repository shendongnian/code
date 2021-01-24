    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortValue => Id == 42 ? 0 : Id;
    }
    _context.Foo.Where(f => somecondition)
                .OrderBy(f => f.SortValue)
                .ToList();
