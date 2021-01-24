	void Main()
	{
		//static initializers
		List<int> expectedElements = new List<int> { 8, 10, 11 };
		List<int> elementHistory = new List<int>();
		IObservable<char> source;
	
		//simulated continuous running of MSpec test
		for (int i = 0; i < 20; i++)
		{
	
			//establish
			source = "Z8\nZ10\nZ11\n".ToObservable();
	
			//because
			source
				.ShutterCurrentReadings()
				.Trace("Unbelievable")
				.SubscribeAndWaitForCompletion(item => elementHistory.Add(item));
	
			//it
			elementHistory.Dump(i.ToString()); //Linqpad
			if(elementHistory.Count > 3)
				throw new Exception("Assert.ShouldNotHappen");
		}
	}
	public static class Extensions
	{
		public static IObservable<int> ShutterCurrentReadings(this IObservable<char> source)
		{
			const string shutterCurrentPattern = @"^Z(?<Current>\d{1,2})[^0-9]";
			var shutterCurrentRegex =
				new Regex(shutterCurrentPattern, RegexOptions.Compiled | RegexOptions.ExplicitCapture);
			var buffers = source.Publish(s => s.BufferByPredicates(p => p == 'Z', q => !char.IsDigit(q)));
			var shutterCurrentValues = from buffer in buffers
									   let message = new string(buffer.ToArray())
									   let patternMatch = shutterCurrentRegex.Match(message)
									   where patternMatch.Success
									   let shutterCurrent = int.Parse(patternMatch.Groups["Current"].Value)
									   select shutterCurrent;
			return shutterCurrentValues.Trace("ShutterCurrent");
		}
	
		public static void SubscribeAndWaitForCompletion<T>(this IObservable<T> sequence, Action<T> observer)
		{
			var sequenceComplete = new ManualResetEvent(false);
			var subscription = sequence.Subscribe(
				onNext: observer,
				onCompleted: () => sequenceComplete.Set()
				);
			sequenceComplete.WaitOne();
			subscription.Dispose();
			sequenceComplete.Dispose();
		}
	
		public static IObservable<TSource> Trace<TSource>(this IObservable<TSource> source, string name)
		{
			var log = LogManager.GetLogger(name);
			var id = 0;
			return Observable.Create<TSource>(observer =>
				{
					var idClosure = ++id;
					Action<string, object> trace = (m, v) => log.Debug("{0}[{1}]: {2}({3})", name, idClosure, m, v);
					trace("Subscribe", "");
					var disposable = source.Subscribe(
						v =>
							{
								trace("OnNext", v);
								observer.OnNext(v);
							},
						e =>
							{
								trace("OnError", "");
								observer.OnError(e);
							},
						() =>
							{
								trace("OnCompleted", "");
								observer.OnCompleted();
							});
					return () =>
						{
							trace("Dispose", "");
							disposable.Dispose();
						};
				});
		}
	
		public static IObservable<IList<char>> BufferByPredicates(this IObservable<char> source,
			Predicate<char> bufferOpening, Predicate<char> bufferClosing)
		{
			return source.Buffer(source.Where(c => bufferOpening(c)), x => source.Where(c => bufferClosing(c)));
		}
	}
