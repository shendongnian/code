    volatile bool run;
    protected async override void OnAppearing()
    {
       base.OnAppearing();
       BindingContext = vm;    
       cts = new CancellationTokenSource();
       if (Settings.mode == MO.Practice)
       {
            run = true;
            Device.StartTimer(new TimeSpan(0, 1, 0), () => 
            {
                if (run) 
                { 
                     if (App.DB.ReducePoints() == true)
                        Device.BeginInvokeOnMainThread(() =>
                        {
                           vm.PifInfo = GetPifInfo();
                        });
                     return true; 
                }
                else { return false; }
            });
            await GetCards(cts.Token);
        }
    }
    
    protected override void OnDisappearing()
    {
        run = false;
        Unsubscribe();
        cts.Cancel();
        base.OnDisappearing();
    }
