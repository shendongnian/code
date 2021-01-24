	var g = new Generator<int>();
	g.Items
		.TakeUntil(i => i > 3)
		.Subscribe(
			i => Console.WriteLine($"OnNext: {i}"), 
			e => Console.WriteLine($"OnError: Message: {e.Message}"), 
			() => Console.WriteLine("OnCompleted")
		);
	g.Push(1);
	g.Push(2);
	g.Push(3);
	g.Push(4);
	g.Push(5);
	g.Push(6);
