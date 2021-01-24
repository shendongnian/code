    ILoginManager _loginManager;
    Mock<IValidations> _validations;
    Mock<IAccountRepository> _accountRepository;
    [SetUp]
    public void Setup() {        
        _validations = new Mock<IValidations>();
        _accountRepository = new Mock<IAccountRepository>();
        _loginManager = new LoginManager(_validations.Object, _accountRepository.Object);
    }   
    [Test]
    public void Login_ValidUser() {
        //Arrange
        var expected = new User();
        _validations.Setup(val => val.IsValidAccount(It.IsAny<User>())).Returns(true);
        _accountRepository.Setup(repo => repo.Login(It.IsAny<User>())).Returns(()=> user);
        //Act
        var actual = _loginManager.Login(expected);
        //Assert
        Assert.That(actual, Is.Not.Null);
        Assert.AreEqual(expected, actual);        
    }
