            [Test]
            public void testGetPhysicalTypeForGenericDictionary()
            {
                IDictionary<int, string> myDictionary = new Dictionary<int, string>();
                Type [] myTypes = myDictionary.GetType().GetGenericArguments();
                Assert.AreEqual(2, myTypes.Length);
                var varTypes = myDictionary.GetType().GetGenericArguments();
                Assert.AreEqual("Int32", varTypes[0].Name);
                Assert.AreEqual("System.Int32", varTypes[0].FullName);
    
                Assert.AreEqual("String", varTypes[1].Name);
                Assert.AreEqual("System.String", varTypes[1].FullName);
            }
