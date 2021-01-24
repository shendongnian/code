    public List<MyObject> GetList(Item item){
        IQueryable<MyObject> qMyobjects = this.GetQueryableList(item, item.ranges.first().item1, item.ranges.first().item2;
    
        item.ranges.Skip(1).ToList().ForEach((Tuple<DateTime, DateTime> range) => {
            IQueryable<MyObject> select = this.GetQueryableList(item, range.item1, range.item2);
            qMyobjects = qMyobjects.Union(select);
        });
        return qMyobjects.ToList();
    }
    
    protected IQueryable<MyObject> GetQueryableList(Item item, DateTime dateFrom, DateTime dateTo){
        return _context.myobjects
            .Where(e => e.category.Equals("somecategory")
            .Where(e => e.date >= dateFrom && e.date <= dateTo);
    }
