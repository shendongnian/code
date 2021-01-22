    Action<PersistenceSpecification<Entry>> testAction = pspec => pspec
                    .CheckProperty(e => e.Id, "1")
                    .VerifyTheMappings();
    HelpTestMethod<Entry>(testAction);
    
    public void HelpTestMethod<T>(Action<PersistenceSpecification<T>> testAction)
    {
        using(var session = new SessionFactory().CreateSession(...))
        {
            testAction(new PersistenceSpecification<T>( session ));
        }
    }
