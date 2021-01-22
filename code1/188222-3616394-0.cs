    var propserties = persistentClass.PropertyClosureIterator;
    if ( persistentClass.Identifier is Component )
    {
        properties = ( ( Component )( persistentClass.Identifier ) ).PropertyIterator
                        .Union( properties );
    }
    
    Property property
        = (
            from it in properties
            where it.Name == propertyName
            select it
          ).FirstOrDefault();
