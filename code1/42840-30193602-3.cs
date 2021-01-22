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
		public void AddRange(
			IEnumerable<T> itemsToAdd,
			ECollectionChangeNotificationMode notificationMode = ECollectionChangeNotificationMode.Add)
		{
			if (itemsToAdd == null)
			{
				throw new ArgumentNullException("itemsToAdd");
			}
			CheckReentrancy();
			if (notificationMode == ECollectionChangeNotificationMode.Reset)
			{
				foreach (var i in itemsToAdd)
				{
					Items.Add(i);
				}
				OnPropertyChanged(new PropertyChangedEventArgs("Count"));
				OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
				return;
			}
			int startIndex = Count;
			var changedItems = itemsToAdd is List<T> ? (List<T>) itemsToAdd : new List<T>(itemsToAdd);
			foreach (var i in changedItems)
			{
				Items.Add(i);
			}
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startIndex));
		}
		public enum ECollectionChangeNotificationMode
		{
			/// <summary>
			/// Notifies that only a portion of data was changed and supplies the changed items (not supported by some elements,
			/// like CollectionView class).
			/// </summary>
			Add,
			/// <summary>
			/// Notifies that the entire collection was changed, does not supply the changed items (may be inneficient with large
			/// collections as requires the full update even if a small portion of items was added).
			/// </summary>
			Reset
		}
	}
