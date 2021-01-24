    public void Start() {
        Started += OnStarted; //subscribe to event
        Started(this, EventArgs.Empty); //raise event
    }
    private event EventHandler Started = delegate { };
    private async void OnStart(object sender, EventArgs args) {
        Started -= OnStarted;        
        await StartAsync();
    }
    public async Task StartAsync() {
        // ...
    }
