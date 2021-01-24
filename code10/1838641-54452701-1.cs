    CancellationTokenSource source;
    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext = vm;
        //subscribe
        start += onStart;
        start(this, EventArgs.Empty);
    }
    private event EventHandler start = delegate { };
    private async void onStart(object sender, EventArgs args) {
        cts = new CancellationTokenSource();
        if (Settings.mode == MO.Practice) {
            source = new CancellationTokenSource();
            var interval = TimeSpan.FromMinutes(1);
            //repeat this function every minute
            Device.StartTimer(interval, () => {
                //check cancellation and break if canceled
                if(source.IsCancellationRequested)
                    return false;
            
                checkPoints();
                
                //While the callback returns true, the timer will keep recurring.
                return true;
            });
            
            await GetCards(cts.Token);
        }
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
