    enum Status { unassigned, assigned, closed };
    class MyType
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
    static void Main(string[] args)
    {
        IEnumerable<MyType> items = new List<MyType>
        {
            new MyType {Id = 123, CreationDate = new DateTime(2018, 12, 19), Status = Status.assigned},
            new MyType {Id = 123, CreationDate = new DateTime(2018, 12, 20), Status = Status.unassigned},
            new MyType {Id = 123, CreationDate = new DateTime(2018, 12, 21), Status = Status.closed},
        };
        var a = items.GroupBy(o => o.Id);
        var b = a.Select(o => o.OrderByDescending(p => p.CreationDate).FirstOrDefault());
        var c = b.Where(o => o != null && o.Status == Status.unassigned);
    }
