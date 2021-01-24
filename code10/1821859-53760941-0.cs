        private void Setup()
		{
			List<Entity> entityData = new List<Entity>();
			entityData.Add(new Entity
			{
				Id = Guid.NewGuid()
			});
			DbSet<Entity> MockEntitySet = GetSet(entityData);
			MockContext = new Mock<IDbContext>();
			MockContext.Setup(m => m.Set<Entity>()).Returns(MockEntitySet);
		}
        public static DbSet<T> GetSet<T>(List<T> sourceList) where T : class
		{
			return GetSet(sourceList.ToArray());
		}
		public static DbSet<T> GetSet<T>(T[] sourceList) where T : class
		{
			var name = typeof(T).Name;
			var queryable = sourceList.AsQueryable();
			Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
			dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
			dbSet.Setup(m => m.AsNoTracking()).Returns(dbSet.Object);
			return dbSet.Object;
		}
        
        [TestMethod]
        public void Test()
        {
            EntityService service = new EntityService(MockContext.Object);
            ComponentToTest compObj = new ComponentToTest(service);
            compObj.MethodToTest(...);
            
            // Assertions
        }
