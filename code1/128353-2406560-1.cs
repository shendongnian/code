	public class ClassWithIndexedEvents {
		public event EventHandler<IndexedEventArgs> IndexedEvent;
		
		public IObservable Events { get; private set; }
		
		public ClassWithIndexedEvents() {
			// yeah, this feels a little weird, but it works
			Events = Observable.FromEvent<IndexedEventArgs>(this, "IndexedEvent");
		}
		
		// ...
	}
