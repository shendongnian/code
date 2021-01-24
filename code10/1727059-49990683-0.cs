    var predicate = LinqKit.PredicateBuilder.New<Entity>();
    foreach(var v in values) {
      predicate.Or(e => v.ColumnA == e.ColumnA && v.ColumnB == e.ColumnB);
    }
    context.Entities
       .Where(predicate)
       .Select(e => e.ID_column);
   
