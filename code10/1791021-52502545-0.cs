    var myProps = ExternalIds
        .Select( id => new MyProperty { Id = id } )
        .ToArray();
    dbContext.AttachRange( myProps ); // tracks as Unchanged
    ...
    entities[ i ].MyProperty = myProps[i];
