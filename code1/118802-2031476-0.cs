    var testAction = pspec => pspec.CheckProperty( e => e.Id, "1" ).VerifyTheMappings();
    HelpTestMethod<Entry>( testAction );
    
    public void HelpTestMethod<T>( Action<T> testAction )
    {
        using( var session = new Session(...) )
        {
            testAction( new PersistenceSpecification<T>( session ) )
        }
    }
