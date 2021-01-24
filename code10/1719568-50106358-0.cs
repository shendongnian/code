    SomeClass classAlias = null
    var subquery = QueryOver.Of<SomeClass>()
                      .SelectList(lst => lst
                                    .SelectGroup(f => f.KeyPart1)
                                    .SelectGroup(f => f.KeyPart2)
                                    .SelectMax(f => f.VersionNo))
                      .Where(x => x.KeyPart1 == classAlias.KeyPart1)
                      .Where(x => x.KeyPart2 == classAlias.KeyPart2)
                      .Where(x => x.VersionNo > classAlias.VersionNo);
    
    var query = Session.QueryOver(() => classAlias)
                   .WithSubQuery.WhereNotExists(subquery);
    var results = query.List();
