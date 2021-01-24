    class ItemAndParent {
        Item A { get; set; }
        string ParentName { get; set; }
    }
    var query = from a in this.DbContext.Items
        join b in this.DbContext.Items
        on a.ParentId equals b.Id
        select new ItemAndParent {
            A = a,
            ParentName = b.Name
        };
