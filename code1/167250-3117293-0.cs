        [Fact]
        public void FullNameOfUnresolvedGenericArgumentIsNull()
        {
            Type openGenericType = typeof(Nullable<>);
            Type typeOfUnresolvedGenericArgument = openGenericType.GetGenericArguments()[0];
            Assert.Null(typeOfUnresolvedGenericArgument.FullName);
        }
