    [Test]
    public GivenAUser_WhenSearchingById_ReturnsTheUser()
    {
        var expectedUsername = "username";
        var user = _context.Given(AUser.WithName(expectedUsername));
        var result = _repository.GetUser(user.Id);
        Assert.That(result.Name, Is.EqualTo(expectedUsername));
    }
