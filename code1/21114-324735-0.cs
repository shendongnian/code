    private int SetupFields( object[] fields )
    {
        fields[ 0 ] = 100;
        fields[ 1 ] = "Hello";
        return 2;
    }
    [Test]
    public void TestGetValues()
    {
        MockRepository mocks = new MockRepository();
    
        using ( mocks.Record() )
        {
            Expect
                .Call( reader.GetValues( null ) )
                .IgnoreArguments()
                .Do( new Func object[], int>( SetupField ) )
        }       
    }
