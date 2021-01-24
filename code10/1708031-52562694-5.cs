     [Fact]
     public async Task CreateAUser()
     {
          var newUser = new ApplicationUser("NewUser", "New@test.com");
          var password = "P@ssw0rd!";
          var result = await _repo.CreateUser(newUser, password);
          Assert.Equal(3, _users.Count);
      }
