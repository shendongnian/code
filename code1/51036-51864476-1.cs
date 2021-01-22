        [Fact]
        public void ImplementsGenericInterface_List_IsValidInterfaceTypes()
        {
            var list = new List<string>();
            Assert.True(list.GetType().ImplementsGenericInterface(typeof(IList<>)));
            Assert.True(list.GetType().ImplementsGenericInterface(typeof(IEnumerable<>)));
            Assert.True(list.GetType().ImplementsGenericInterface(typeof(IReadOnlyList<>)));
        }
        [Fact]
        public void ImplementsGenericInterface_List_IsNotInvalidInterfaceTypes()
        {
            var list = new List<string>();
            Assert.False(list.GetType().ImplementsGenericInterface(typeof(string)));
            Assert.False(list.GetType().ImplementsGenericInterface(typeof(IDictionary<,>)));
            Assert.False(list.GetType().ImplementsGenericInterface(typeof(IComparable<>)));
            Assert.False(list.GetType().ImplementsGenericInterface(typeof(DateTime)));
        }
