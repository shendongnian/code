    Dictionary<Func<bool>, Expression<Func<Order, bool>>> filters =
      new Dictionary<Func<bool>, Expression<Func<Order, bool>>>();
    // add a name filter
    filters.Add(
      () => txtName.Text.Length > 0,
      a => a.Name.StartsWith(txtName.Text)
    );
    // add a type filter
    filters.Add(
      () => txtType.Text.Length > 0,
      a => a.Type == txtType.Text
    );
...
    var query = dc.Orders.AsQueryable();
    
    foreach( var filter in filters
      .Where(kvp => kvp.Key())
      .Select(kvp => kvp.Value) )
    {
      var inScopeFilter = filter;
      query = query.Where(inScopeFilter);
    }
