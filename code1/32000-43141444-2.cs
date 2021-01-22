        [TestMethod()]
        public void GetPublicGenericPropertiesChangedTest1()
        {
            // Define objects to test
            Function func1 = new Function { Id = 1, Description = "func1" };
            Function func2 = new Function { Id = 2, Description = "func2" };
            FunctionAssignment funcAss1 = new FunctionAssignment
            {
                Function = func1,
                Level = 1
            };
            FunctionAssignment funcAss2 = new FunctionAssignment
            {
                Function = func2,
                Level = 2
            };
            // Main test: read properties changed
            var propertiesChanged = Utils.GetPublicGenericPropertiesChanged(funcAss1, funcAss2, null);
            Assert.IsNotNull(propertiesChanged);
            Assert.IsTrue(propertiesChanged.Count == 3);
            Assert.IsTrue(propertiesChanged[0].PropertyName == "FunctionAssignment.Function.Description");
            Assert.IsTrue(propertiesChanged[1].PropertyName == "FunctionAssignment.Function.Id");
            Assert.IsTrue(propertiesChanged[2].PropertyName == "FunctionAssignment.Level");
        }
