    void Authorize(RequiresAuthorization item)
    {
        var dbItem = ChildContainer.Resolve<IAuthorizationRepository>()
                                   .RetrieveRequiresAuthorizationById(item.Id);
        var authorizerType = type.GetType(String.Format("Foo.Authorizer`1[[{0}]], Foo",
                                 dbItem.GetType().AssemblyQualifiedName));
        dynamic authorizer = ChildContainer.Resolve(type) as dynamic;
    
        authorizer.Authorize(dbItem as dynamic); // <<<Note "as" here
    }
