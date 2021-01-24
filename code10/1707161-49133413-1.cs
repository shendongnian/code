                var ts = new TestScheduler();
                System.Reactive.Unit resp = null;
    
                var obs = Observable.Return(System.Reactive.Unit.Default).Delay(TimeSpan.FromTicks(1000),ts).Subscribe(r => { resp = r; });
                ts.AdvanceBy(1000);
                resp.ShouldNotBeNull();
