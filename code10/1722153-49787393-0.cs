    [Test]  
    public async Task HttpPost_CreatePost_When_Model_Is_Invalid_Returns_Error() {    
        // Arrange
        var expectedErrorMessage = "Invalid input";
        var model = new SavePostViewModel() {
            //Author = "Tamim Iqbal",
            Content = "New Content",
            IsPublished = true,
            //Subject = "New Subject",
            //PostDate = Helper.LocalDateToday,
        };
        //Adding model state to force it to be invalid
        _blogController.ModelState.AddModelError("", "invalid data");
    
        // Act
        var result = await _blogController.CreatePost(model) as ViewResult;
        var actualErrorMessage = result.ViewData["ERROR_MESSAGE"];
    
        // Assert
        Assert.AreEqual(expectedErrorMessage, actualErrorMessage);    
    }
