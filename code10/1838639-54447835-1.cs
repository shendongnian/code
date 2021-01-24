    protected async override void OnAppearing()
    {
       _sub = Observable.Timer(0, TimeSpan.FromMinutes(1))
               .ObserveOnDispatcher() // move invocation to dispatcher
               .Do(_ => {
                      vm.PifInfo = GetPifInfo(); // do your work. Try/catch will be usefull, otherwise any exception will break the subscription
                })
           //    .Retry() // uncomment this if you want to immedietally try again after a failure, no try/catch then
               .Subscribe();
    
        ....
    
    }
    
    protected override void OnDisappearing()
    {
       _sub?.Dispose(); // this will unsubscribe to the timer
       ...
    }
