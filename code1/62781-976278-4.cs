    //Theoretical, non-compiling example....
    foreach (IGenericRelation<,> relationControl in this.uiPlhControls.Controls.OfType<IGenericRelation<,>>)
    { 
        //This wouldn't work for type IGenericRelation<Fizz, Buzz>
        relationControl.Parent.FooProperty = "Wibble";
        //You would be able to access this, but there is no advantage over using IRelation
        relationControl.RelationshipType = "Wibble";
    }
