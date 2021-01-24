    public IQueryable<MyThing> SelectAggregatedFirstsOfMyThings(IOrderedQueryable<MyThing> myThings) =>
        myThings.GroupBy(t => t.MyFkId)
                .AsEnumerable()
                .Select(g => {
                    var r = new MyThing(g.First());
                    r.MyDate = g.Max(d => d.MyDate);
                    // assign remaining aggregated properties ...
                    return r;
                 });
