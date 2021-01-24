	TestScheduler ts = new TestScheduler();
	var stockSource = ts.CreateHotObservable<Stock>(
		new Recorded<Notification<Stock>>(10.MsTicks(), Notification.CreateOnNext(new Stock("MSFT"))),
		new Recorded<Notification<Stock>>(20.MsTicks(), Notification.CreateOnNext(new Stock("GOOG"))),
		new Recorded<Notification<Stock>>(30.MsTicks(), Notification.CreateOnNext(new Stock("AAPL")))
	);
	var priceSource = ts.CreateHotObservable<StockPrice>(
		new Recorded<Notification<StockPrice>>(20.MsTicks(), Notification.CreateOnNext(new StockPrice(new Stock("AAPL"), 10m))),
		new Recorded<Notification<StockPrice>>(40.MsTicks(), Notification.CreateOnNext(new StockPrice(new Stock("GOOG"), 15m)))
	);
	var target = priceSource.Publish(_prices =>
		stockSource
			.Select(s => (Stock: s, StockPrices: _prices
				.TakeUntil(Observable.Timer(TimeSpan.FromMilliseconds(100), ts))
				.Where(p => p.Stock.Symbol == s.Symbol)
			))
		);
	var observer = ts.CreateObserver<(Stock, IObservable<StockPrice>)>();
	target.Subscribe(observer);
	var target2 = target.SelectMany(t => t.StockPrices.Select(sp => (Stock: t.Stock, Price: sp)));
	var observer2 = ts.CreateObserver<(Stock, StockPrice)>();
	target2.Subscribe(observer2);
	ts.Start();
	observer.Messages.Dump();	//LinqPad
	observer2.Messages.Dump();	//LinqPad
