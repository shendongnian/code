    	public class ReadOnlyObservableCollectionWithCollectionChangeNotifications<T> : ReadOnlyObservableCollection<T>
	{
		public ReadOnlyObservableCollectionWithCollectionChangeNotifications(ObservableCollection<T> list)
			: base(list)
		{
		}
		event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged2
		{
			add { CollectionChanged += value; }
			remove { CollectionChanged -= value; }
		}
	}
