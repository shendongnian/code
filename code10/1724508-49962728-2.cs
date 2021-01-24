        [Test]
        public void TestThatDoSomeStuffCallsMethodToBeTested()
        {
            //Create your mock and class being tested
            IIterface realMock = Substitute.ForPartsOf<RealClass>();
            var classBeingTested = new ClassThatUsesMockedClass(realMock);
            //Call the method you're testing
            classBeingTested.DoSomeStuff();
            //Assert that MethodToBeTested was actually called
            realMock.Received().MethodToBeTested(Arg.Any<int>());
        }
