    CancellationTokenSource source;
    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext = vm;
        start += onStart;
        start(this, EventArgs.Empty);
    }
    private event EventHandler start = delegate { };
    private async void onStart(object sender, EventArgs args) {
        cts = new CancellationTokenSource();
        if (Settings.mode == MO.Practice) {
            source = new CancellationTokenSource();
            var interval = TimeSpan.FromMinutes(1);
            Func<bool> callback = () => {
                if(source.IsCancellationRequested) return false;
            
                checkPoints();
                
                //While the callback returns true, the timer will keep recurring.
                return true;
            };
            //repeat this function every minute
            Device.StartTimer(interval, callback);
            
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
