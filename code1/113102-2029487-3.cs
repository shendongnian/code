    [TestMethod]
        public void ClassUnderTest_DefaultAnsweredYes_IsFalse()
        {
            var classUnderTest = new ClassUnderTest();
            Assert.AreEqual(false, classUnderTest.AnsweredYes);
        }
        [TestMethod]
        public void MyMethod_UserAnswersYes_AnsweredYesIsTrue()
        {
            //Test Setup
            Func<string, string, MessageBoxButtons, DialogResult> 
                fakeMessageBoxfunction =
                        (text, caption, buttons) =>
                        DialogResult.Yes;
            //Create an instance of the class you are testing
            var classUnderTest = new Testing.ClassUnderTest();
            var oldDependency = Testing.ClassUnderTest.MessageBoxDependency;
            Testing.ClassUnderTest.MessageBoxDependency = fakeMessageBoxfunction;
            try
            {
                classUnderTest.MyMethod(null, null);
                Assert.AreEqual(true, classUnderTest.AnsweredYes);
                //Assert What are you trying to test?
            }
            finally
            { //Ensure that future tests are in the default state
                Testing.ClassUnderTest.MessageBoxDependency = oldDependency;
            }
        }
