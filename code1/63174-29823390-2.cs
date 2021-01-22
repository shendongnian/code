     [Test]
        public void SimpleGenericInterfaces()
        {
            Assert.IsTrue(typeof(Table<string>).IsOfGenericType(typeof(IEnumerable<>)));
            Assert.IsTrue(typeof(Table<string>).IsOfGenericType(typeof(IQueryable<>)));
    
            Type concreteType;
            Assert.IsTrue(typeof(Table<string>).IsOfGenericType(typeof(IEnumerable<>), out concreteType));
            Assert.AreEqual(typeof(IEnumerable<string>), concreteType);
    
            Assert.IsTrue(typeof(Table<string>).IsOfGenericType(typeof(IQueryable<>), out concreteType));
            Assert.AreEqual(typeof(IQueryable<string>), concreteType);
    
           
        }
