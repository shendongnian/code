	var scheduler = new TestScheduler();
	var input1 = scheduler.CreateColdObservable<int>(
		ReactiveTest.OnNext(1000.Ms(), 1),
		ReactiveTest.OnNext(2000.Ms(), 2),
		ReactiveTest.OnNext(3000.Ms(), 3),
		ReactiveTest.OnNext(4000.Ms(), 4),
		ReactiveTest.OnNext(5000.Ms(), 5),
		ReactiveTest.OnNext(6000.Ms(), 6),
		ReactiveTest.OnNext(7000.Ms(), 7)
	);
	var input2 = scheduler.CreateColdObservable<string>(
		ReactiveTest.OnNext(1400.Ms(), "a"),
		ReactiveTest.OnNext(1500.Ms(), "b"),
		ReactiveTest.OnNext(1600.Ms(), "c"),
		ReactiveTest.OnNext(5500.Ms(), "d"),
		ReactiveTest.OnNext(5600.Ms(), "e"),
		ReactiveTest.OnNext(5700.Ms(), "f")
	);
	
	Subject<string> queue = new Subject<string>();
	input2.Subscribe(queue);
	var result = queue
		.Buffer(() => input1)
		.Do(l => { foreach (var n in l.Skip(l.Count > 1 ? 1 : 0)) queue.OnNext(n); })
		.Where(l => l.Count > 0)
		.Select(l => l[0]);
	result.Timestamp(scheduler)
		.Select(t => $"{t.Timestamp.Ticks} ticks: {t.Value}")
		.Dump(); //Linqpad
