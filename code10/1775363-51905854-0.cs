    public PhrasesFrame() {
        InitializeComponent();
        fRequested += onfRequested; //subscribe to event
        MessagingCenter.Subscribe<PhrasesFrameViewModel>(this, "FBtn", (s) => 
            //Raise event
            fRequested(s, EventArgs.Empty));
    }
    
    private event EventHandler fRequested = delegate { };
    private async void onfRequested(object sender, EventArgs args) {
        //Await async task
        await FBtn();
    }
    
    public  async Task FBtn() {
        // code here
        await Task.Run(() => App.DB.UpdateFavorite(phrase.Favorite, phrase.PhraseId));
        // code here
    }
