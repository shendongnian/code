    Mock<IRepository> repositoryMock = new Mock<IRepository>();
    CustomAttribute attribute = new CustomAttribute();
    // option #1: to the instance
    TypeDescriptor.AddAttributes(repositoryMock.Object, attribute );
    // option #2: to the generated type
    TypeDescriptor.AddAttributes(repositoryMock.Object.GetType(), attributes);
