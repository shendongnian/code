    [Test()]
    public async Task SubmitStats_WhenTouched_ShouldNavigateToNotesPage() {
        //Arrange
        var tcs = new TaskCompletionSource<object>();
        _apiService.Setup(a => a.PostStats(It.IsAny<SequenceRating>())).ReturnsAsync(true);
        _pageService.Setup(p => p.PushAsync(It.IsAny<ExerciseNotes>()))
            .Returns(Task.FromResult((object)null))
            .Callback(() => tcs.SetResult(null));
        // Act
         _exerciseRatingViewModel.SubmitRatingsCommand.Execute(null);
        await tcs.Task; //wait for async flow to complete
        //Assert
        _apiService.Verify(a => a.PostStats(It.IsAny<SequenceRating>()));
        _pageService.Verify(p => p.PushAsync(It.IsAny<ExerciseNotes>()));
    }
