    [Test()]
    public async Task SubmitStats_WhenTouched_ShouldNavigateToNotesPage() {
        //Arrange
        _apiService.Setup(a => a.PostStats(It.IsAny<SequenceRating>())).ReturnsAsync(true);
        _pageService.Setup(p => p.PushAsync(It.IsAny<ExerciseNotes>()))
            .Returns(Task.FromResult((object)null));
        // Act
        await _exerciseRatingViewModel.SubmitStats;
        //Assert
        _apiService.Verify(a => a.PostStats(It.IsAny<SequenceRating>()));
        _pageService.Verify(p => p.PushAsync(It.IsAny<ExerciseNotes>()));
    }
