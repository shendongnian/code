    SomeEntityObject entity = DataAccessObject.GetSomeEntityObject( id );
    List<PropertyInfo> properties = entity.GetType().GetPublicNonCollectionProperties( );
    
    // wordify the property names to act as column headers for an html table or something
    List<string> columns = properties.Select( p => p.Name.Capitalize( ).Wordify( ) ).ToList( );
