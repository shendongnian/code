    public static class DatabaseMockSetProvider<TEntity> where TEntity: class
    {
        public static DbSet<TEntity> CreateMockedDbSet(IQueryable<TEntity> mockData)
        {
            var mockSet = Mock.Create<DbSet<TEntity>>();
            Mock.Arrange(() => ((IDbAsyncEnumerable<TEntity>)mockSet).GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<TEntity>(mockData.GetEnumerator()));
            Mock.Arrange(() => ((IQueryable<TEntity>)mockSet).Provider)
                .Returns(new TestDbAsyncQueryProvider<TEntity>(mockData.Provider));
            Mock.Arrange(() => ((IQueryable<TEntity>)mockSet).Expression).Returns(mockData.Expression);
            Mock.Arrange(() => ((IQueryable<TEntity>)mockSet).ElementType).Returns(mockData.ElementType);
            Mock.Arrange(() => ((IQueryable<TEntity>)mockSet).GetEnumerator()).Returns(mockData.GetEnumerator());
            return mockSet;
        }
    }
