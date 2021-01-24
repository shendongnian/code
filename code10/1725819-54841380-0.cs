    var models = new object[]
    {
        ⋮
    }.AsQueryable();
    var mapper = new Mock<IMapper>();
    mapper.Setup(x => x.ProjectTo(
            It.IsAny<IQueryable>(),
            It.IsAny<object>(),
            It.IsAny<Expression<Func<object, object>>[]>()))
        .Returns(models);
