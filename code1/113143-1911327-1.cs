    DatabaseOneDataContext context = new DatabaseOneDataContext();
    var query = from s in context.RealTable
                join t in context.ExternalTable
                  on s.ID equals t.ID
                select new { s, t };
    Console.WriteLine(query.ToList().Count);
