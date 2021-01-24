     public static DbSet<T> MockDbSet<T>(params T[] items) where T : class
        {
            IEnumerable<T> ts = items;
            var mock = new Mock<DbSet<T>>();
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(ts.GetEnumerator());
            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(items.AsQueryable().Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(items.AsQueryable().Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(items.AsQueryable().ElementType);
    
            return mock.Object;
        }
