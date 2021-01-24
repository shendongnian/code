	//Create a new subject
	Subject<int> subject = new Subject<int>();
	//Observe the subject until some pre-determined stopping criteria
	IObservable<int> sequence = subject.TakeWhile(x => x <= 50);
	sequence
		.ToList()
		.Subscribe(list =>
		{
			Console.WriteLine(String.Join(", ", list));
		});
	//fake bluetooth messages
	int i = 0;
	while (i < 100)
		subject.OnNext(i++);
