    [Test]
    public void Edit_GivenFormsCollection_CanPersistStyleChanges()
    {
        //Blah
    
        var nameValueCollection = new NameValueCollection();
        InitFormCollectionWithSomeChanges(nameValueCollection, style);
        //Removed stuff
        controller.Edit(1, new FormCollection(nameValueCollection));
    
        //Blah
    }
