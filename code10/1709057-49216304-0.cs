	public class MyObservableCollection : ObservableCollection<Names>
	{
		public MyObservableCollection()
		{
			CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
			{
				OnPropertyChanged(new PropertyChangedEventArgs("NewCount"));
			};
		}
		public int NewCount
		{
			get { return this.Count((Names arg) => arg.Status == "new"); }
		}
	}
