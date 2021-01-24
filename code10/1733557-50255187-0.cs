        public static class MockDbSetExtensions
    {
        public static void SetSource<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class
        {
            var data = source.AsQueryable();
            var iQuryableSet = mockSet.As<IQueryable<T>>();
            iQuryableSet.SetupGet(m => m.Provider).Returns(data.Provider);
            iQuryableSet.SetupGet(m => m.Expression).Returns(data.Expression);
            iQuryableSet.SetupGet(m => m.ElementType).Returns(data.ElementType);
            iQuryableSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        }
    }
