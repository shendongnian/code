        [Test]
        public void GenerateTest()
        {
            var typeDictionary = new Dictionary<string, Type>
            {
                {"Field1", typeof (string)},
                {"Field2", typeof (double)},
                {"Field3", typeof (decimal)},
                {"Field4", typeof (DateTime)},
                {"Field5", typeof (float)}
            };
            var type = DependencyPropertyGenerator.Generate(typeDictionary);
            foreach (var fieldName in typeDictionary.Keys)
            {
                var dp = DependencyPropertyDescriptor.FromName(fieldName, type, type);
                Assert.IsNotNull(dp.DependencyProperty);
                Assert.AreEqual(dp.DependencyProperty.Name,fieldName);
                Assert.AreEqual(dp.DependencyProperty.PropertyType , typeDictionary[fieldName]);
            }
        }
