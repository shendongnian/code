    return Observable.Create<string>(observer => {
        var ev = new Events();
        var ob = Observable.FromEvent<string>(x => ev.MessageArrived += x, x => ev.MessageArrived -= x);
        var sub = ob.Subscribe(observer);                    
        ev.Start();                
        return new CompositeDisposable(sub, Disposable.Create(() => ev.Stop()));
    }).Publish().RefCount(); 
