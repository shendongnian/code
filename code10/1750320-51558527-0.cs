	public class View
	{
		public event EventHandler ProductSaveButtonEventRaised; 
	}
	
	public class Presenter
	{
		// Obervables are first class citizens, meaning you can pass them around or expose them as a property
		public IObservable<EventPattern<EventArgs>> ProductSavedEvents { get; private set;}				
		
		public Presenter(View view)
		{
			// Turn a regular event into an Observable
			ProductSavedEvents = Observable.FromEventPattern<EventHandler, EventArgs>(
					h => view.ProductSaveButtonEventRaised += h,
					h => view.ProductSaveButtonEventRaised -= h);
		}
	}
	
	public class PresenterCreator
	{
		Presenter presenter = new Presenter(new View());
		
		public void Subscribe()
		{
			// Act on a save button event
			presenter.ProductSavedEvents.Subscribe(@event => Console.WriteLine(@event));
			
			var otherConsumer = new OtherConsumer(presenter.ProductSavedEvents);
		}
	}
	
	public class OtherConsumer
	{
		// You can pass observables just like any other object. Can't do that with events
		public OtherConsumer(IObservable<EventPattern<EventArgs>> ProductSavedEvents)
		{
			// Act on a save button event
			ProductSavedEvents.Subscribe(@event => Console.WriteLine(@event));
		}
	}
