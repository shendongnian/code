    private IDataReader MockIDataReader()
    {
        var moq = new Mock<IDataReader>();
        moq.SetupSequence( x => x.Read() )
           .Returns( true )
           .Returns( false );
        moq.SetupGet<object>( x => x["Char"] ).Returns( 'C' );
    
        return moq.Object; 
    }
