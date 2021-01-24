    CancellationTokenSource source;
    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext = vm;
        startTimer += onTimerStarted;
        startTimer(this, EventArgs.Empty);
    }
    private event EventHandler startTimer = delegate { };
    private async void onTimerStarted(object sender, EventArgs args) {
        cts = new CancellationTokenSource();
        if (Settings.mode == MO.Practice) {
            source = new CancellationTokenSource();
            StartTimer(source.Token);
            await GetCards(cts.Token);
        }
    }
    private void StartTimer(CancellationToken token) {        
        var interval = TimeSpan.FromMinutes(1);
        Func<bool> callback = () => {
            //check if to stop timer
            if(token.IsCancellationRequested) return false;
            //Code to be repeated
            checkPoints();            
            //While the callback returns true, the timer will keep recurring.
            return true;
        };
        //repeat this function every minute
        Device.StartTimer(interval, callback);
    }
    private void checkPoints() {
        // Here's the method I want to run. After it's finished
        // I call BeginInvoke .. to update info on the screen
        if (App.DB.ReducePoints() == true) {
            Device.BeginInvokeOnMainThread(() => {
                vm.PifInfo = GetPifInfo();
            });
        }
    }
    protected override void OnDisappearing() {        
        source.Cancel();//Timer will short-circuit on next interval
        Unsubscribe();
        cts.Cancel();        
        base.OnDisappearing();
    }
