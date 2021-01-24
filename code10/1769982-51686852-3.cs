    [Test]
    public async Task When_PostingCreateBankThatIsInvalid_ThenBankIsReturned() {
        //Arrange
        var bank = new Bank
        {
            //nothing set = invalid state - this is what we want
        };
        var controller = new BanksController(null);
        controller.ModelState.AddModelError("Name","Name required");
    
        //Act
        var response = await controller.Create(bank);
    
        //Assert
        response.Should().NotBeNull()
            .And.BeOfType<ViewResult>();
        var viewResult = response as ViewResult;
        viewResult.Model.Should().Be(model);
    }
