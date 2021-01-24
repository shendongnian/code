    public ExerciseRatingViewModel(int sequenceID, IPageService pageService, IDataService dataService, IAPIService apiService) {
        _sequenceID = sequenceID;
        _pageService = pageService;
        _dataService = dataService;
        _apiService = apiService;
        submitted += onSubmitted; //subscribe to event
        SubmitRatingsCommand = new Command(() => submitted(null, EventArgs.Empty));
    }
    private event EventHandler submitted = delegate { };
    private async void onSubmitted(object sender, EventArgs args) { //event handler
        await SubmitStats();
    }
    private async Task SubmitStats() {
        int userID = _dataService.GetUserID();
        SequenceRating sequenceRating = new SequenceRating(_sequenceID, userID, DifficultyRating, PainRating, MobilityRating);
        bool success = await _apiService.PostStats(sequenceRating);
        await _pageService.PushAsync(new ExerciseNotes());
    }      
