    public TrulyObservableCollection()
			: base()
		{
			HookupCollectionChangedEvent();
		}
		public TrulyObservableCollection(IEnumerable<T> collection)
			: base(collection)
		{
			foreach (T item in collection)
				item.PropertyChanged += ItemPropertyChanged;
			HookupCollectionChangedEvent();
		}
		public TrulyObservableCollection(List<T> list)
			: base(list)
		{
			list.ForEach(item => item.PropertyChanged += ItemPropertyChanged);
			HookupCollectionChangedEvent();
		}
		private void HookupCollectionChangedEvent()
		{
			CollectionChanged += new NotifyCollectionChangedEventHandler(TrulyObservableCollectionChanged);
		}
