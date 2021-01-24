    // a => 
    var par = Expression.Parameter(typeof(CustomClass), "a");
    // a.Id
    var id = Expression.Property(par, nameof(CustomClass.Id));
    // 10
    var val = Expression.Constant(10);
    // a.Id == 10
    var eq = Expression.Equal(id, val);
    // a => a.Id == 10
    var lambda = Expression.Lambda<Func<CustomClass, bool>>(eq, par);
