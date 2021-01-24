    using ( AutoMock mock = AutoMock.GetLoose() ) {
       
        mock.Setup<SomeInterface>(_ => 
            _.someFunction(
                It.IsAny<string>(),
                It.Is<string>( s => s.Equals( "Specific string" ),
                It.IsAny<string>()
            ) 
        );
        //...           
    }
