    // Arrange
    var mockFoo = MockRepository.GenerateMock< Foo >();
    
    using( mockFoo.GetRepository().Ordered() )
    {
       mockFoo.Expect( x => x.SomeMethod() );
       mockFoo.Expect( x => x.SomeOtherMethod() );
    }
    mockFoo.Replay(); //this is a necessary leftover from the old days...
    
    // Act
    classToTest.BarMethod
    
    //Assert
    mockFoo.VerifyAllExpectations();
