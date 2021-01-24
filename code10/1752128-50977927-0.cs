    public Stub : IParent
    {
        public bool IsValid(int number) { get { return true; } }
    }
    //Arrange
    var list = Enumerable.Range(1,10).Select( i => new Stub() ).ToList();
    var o = new ClassUnderTest();
    
    //Act
    var result = o.ValidateParent(list, 7);
    //Assert
    Assert.IsTrue(result);
    
     
