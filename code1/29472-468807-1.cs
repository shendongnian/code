    [TestMethod]
        public void CheckInteractionWithSomeClass()
        {
            MockRepository mocks = new MockRepository();
            ISomeClass someClass = mocks.StrictMock<ISomeClass>();
            using (mocks.Record())
            {
                //record expection that someClass.SomeMethod will be called...
                someClass.SomeMethod();
            }
            using (mocks.Playback())
            {
                //setup class under test - ISomeClass is injected through the constructor here...
                ClassUnderTest o = new ClassUnderTest(someClass);
                o.MethodOnClassUnderTestThatShouldCallSomeClass.SomeMethod();
                //any other assertions...
            }
        }
