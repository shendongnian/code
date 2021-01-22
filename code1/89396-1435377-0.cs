    class MyTable
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public MyTable(int id, int? parentId) { this.Id = id; this.ParentId = parentId; }
    }
    
    List<MyTable> allTables = new List<MyTable> {
        new MyTable(0, null), 
        new MyTable(1, 0),
        new MyTable(2, 1)
    };
    
    Func<int, IEnumerable<MyTable>> f = null;
    f = (id) =>
    {
        IEnumerable<MyTable> table = allTables.Where(t => t.Id == id);
    
        if (allTables
            .Where(t => t.ParentId.HasValue && t.ParentId.Value == table
                .First().Id).Count() != 0)
            return table
                .Union(f(
                allTables.Where(t => t.ParentId.HasValue && t.ParentId.Value == table
                    .First().Id).First().Id));
        else return table;
    
    };
