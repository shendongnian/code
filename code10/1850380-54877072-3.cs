	void Main()
	{
		var MyList = new ObservableCollection<int>();
	
		IDisposable subscription =
			Observable
				.FromEventPattern
					<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
						x => MyList.CollectionChanged += x,
						x => MyList.CollectionChanged -= x)
				.Where(x => x.EventArgs.Action == NotifyCollectionChangedAction.Add)
				.SelectMany(x => x.EventArgs.NewItems.Cast<MyCustomClass>())
				.SelectMany(x =>
				{
					CallMethodWhenAddItem(x);
					return x.OnPropertyChange(nameof(x.MyCustomProperty));
				})
				.Where(x => x.MyCustomProperty == "SomeValue")
				.Subscribe(_ => { });
	}
	
	public static class Ex
	{
		public static IObservable<T> OnPropertyChange<T>(this T currentSource, string propertyName)
			where T : INotifyPropertyChanged
		{
			return
				Observable
					.FromEventPattern
						<PropertyChangedEventHandler, PropertyChangedEventArgs>(
							eventHandler => eventHandler.Invoke,
							x => currentSource.PropertyChanged += x,
							x => currentSource.PropertyChanged -= x)
					.Where(x => x.EventArgs.PropertyName == propertyName)
					.Select(x => currentSource);
		}
	}
	public class MyCustomClass : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public string  MyCustomProperty { get; set; }
	}
	
	public void CallMethodWhenAddItem(MyCustomClass x) { }
