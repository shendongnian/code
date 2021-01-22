    using System.Reflection;
    
    //snip...
    
    RadioButton rdb = this.Control as RadioButton;
    string uniqueGroupName = rdb.GetType().GetProperty("UniqueGroupName",
        BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rdb, null) as string;
