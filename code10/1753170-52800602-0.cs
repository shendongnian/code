    //1 - create a List<T> with test items
    var users = new List<UserEntity>()
    {
      new UserEntity{LastName = "ExistLastName", DateOfBirth = DateTime.Parse("01/20/2012")},
      ...
    };
    
    //2 - build mock by extension
    var mock = users.AsQueryable().BuildMock();
    
    //3 - setup the mock as Queryable for Moq
    _userRepository.Setup(x => x.GetQueryable()).Returns(mock.Object);
    
    //3 - setup the mock as Queryable for NSubstitute
    _userRepository.GetQueryable().Returns(mock);
