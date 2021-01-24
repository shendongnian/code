    List<Tuple<DateTime, DateTime>> ranges = new List<Tuple<DateTime, DateTime>>{
                new Tuple<DateTime, DateTime>(new DateTime(2018,11,01), new DateTime(2018, 11,05)),
                new Tuple<DateTime, DateTime>(new DateTime(2018,10,25), new DateTime(2018,10,31))};
    
    IQueryable<item> items = context.items.Where(e => e.category.equals("somecategory"));
    
    var result = (from i in items
                  from r in ranges
                  where i.date >= r.Item1 && i.date <= r.Item2
                  select i).ToList();
