        [Test]
        public void Simple_Partial_Mock_Test()
        {
            const string param = "anything";
            var mockTestClass = MockRepository.GenerateMock<TestClass.();
            mockTestClass.Expect( m => m.MethodToMock(param) ).Return( true );
 
            //this is what i want to test
            Assert.IsTrue(mockTestClass.MethodIWantToTest(param));
            mockTestClass.VerifyAllExpectations();
        }
