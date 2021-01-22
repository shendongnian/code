    public sealed class ObservableCollectionEx<T> : ObservableCollection<T>
	{
		#region Ctor
		public ObservableCollectionEx()
		{
		}
		public ObservableCollectionEx(List<T> list) : base(list)
		{
		}
		public ObservableCollectionEx(IEnumerable<T> collection) : base(collection)
		{
		}
		#endregion
		/// <summary> 
		/// Adds the elements of the specified collection to the end of the ObservableCollection(Of T). 
		/// </summary> 
		public void AddRange(IEnumerable<T> itemsToAdd)
		{
			if (itemsToAdd == null)
			{
				throw new ArgumentNullException("itemsToAdd");
			}
			CheckReentrancy();
			int startingIndex = Count;
			var changedItems = new List<T>(itemsToAdd);
			foreach (var i in changedItems)
			{
				Items.Add(i);
			}
			
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startingIndex));
		}
	}
