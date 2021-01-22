    public IDictionary<string, int> FindStudentsDistinctWithQuantity()
    {
        Database db = new Database();
        var students= (from s in db.Students
                    group s by s.Name into g
                    select new {Name = g.Key, Quantity = g.Count()});
        return students.ToDictionary(s => s.Name, s => s.Quantity);
    }
