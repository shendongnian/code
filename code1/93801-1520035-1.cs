    [Test]
        public void Test()
        {
            //Arrange
            var sth= MockRepository.GenerateMock<ISth>();  
            sth.Expect(x=>sth.A()).Return("sth");
    
            //Act
            FunctionBeingTested(sth);
            //Assert
            sth.VerifyAllExpectations();
        }
