    var query = db.Table;
    if (x == y)
    {
       query = query.Where( d.Attr == z );
    }
    else
    {
       query = query.Where( d.Attr == t );
    }
    var predicate = PredicateBuilder.True<Foo>()
                                    .And( f => f.Attr == y )
                                    .And( f => f.Attr == x )
                                    .Or( f => f.Attr == z );
    var query = db.Foo.Where( predicate );
                                   
