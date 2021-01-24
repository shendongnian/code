	int[] timings = new [] { 3000, 1200, 500, 400, 500, 1200, 500, 400 };
	
	IObservable<System.Drawing.Color> sequence =
		Observable
			.Generate(
				0,
				x => x < timings.Length,
				x => x + 1,
				x => x % 2 == 1 ? System.Drawing.Color.DodgerBlue : System.Drawing.Color.Gray,
				x => TimeSpan.FromMilliseconds(timings[x]));
	IDisposable subscription =
		sequence
			.Repeat()
			.ObserveOn(BlinkLight)
			.Subscribe(color => BlinkLight.BackColor = color);
