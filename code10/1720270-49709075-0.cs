    [Fact]
    public void Test_GetSubmissionCategories()
    {
        // Arrange
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new YourMappingProfile());
        }
        var mapper = config.CreateMapper();
        var repo = new SubmissionCategoryRepositoryForTesting();
        var sut = new SubmissionCategoryService(mapper, repo);
        // Act
        var result = sut.GetSubmissionCategories(ConferenceId: 1);
        // Assert on result
    }
