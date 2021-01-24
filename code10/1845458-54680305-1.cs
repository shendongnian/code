	var mockSet = new Mock<DbSet<Blog>>();
	mockSet.As<IDbAsyncEnumerable<Blog>>()
		.Setup(m => m.GetAsyncEnumerator())
		.Returns(new TestDbAsyncEnumerator<Blog>(data.GetEnumerator()));
	mockSet.As<IQueryable<Blog>>()
		.Setup(m => m.Provider)
		.Returns(new TestDbAsyncQueryProvider<Blog>(data.Provider));
	mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
	mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
	mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
