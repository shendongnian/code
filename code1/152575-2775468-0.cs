		public ObservableCollection<WorkItem> WorkItems
		{
			get { return (ObservableCollection<WorkItem>)GetValue(WorkItemsProperty); }
			set { SetValue(WorkItemsProperty, value); }
		}
		// Using a DependencyProperty as the backing store for WorkItems.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty WorkItemsProperty =
			DependencyProperty.Register("WorkItems", typeof(ObservableCollection<WorkItem>), typeof(DragGrid), new FrameworkPropertyMetadata(null, OnWorkItemsChanged));
		private static void OnWorkItemsChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DragGrid me = sender as DragGrid;
			var old = e.OldValue as ObservableCollection<WorkItem>;
			if (old != null)
				old.CollectionChanged -= me.OnWorkCollectionChanged;
			var n = e.NewValue as ObservableCollection<WorkItem>;
			if (n != null)
				n.CollectionChanged += me.OnWorkCollectionChanged;
		}
		private void OnWorkCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				// Clear and update entire collection
			}
			if (e.NewItems != null)
			{
				foreach (WorkItem item in e.NewItems)
				{
					// Subscribe for changes on item
					item.PropertyChanged += OnWorkItemChanged;
					// Add item to internal collection
				}
			}
			if (e.OldItems != null)
			{
				foreach (WorkItem item in e.OldItems)
				{
					// Unsubscribe for changes on item
					item.PropertyChanged -= OnWorkItemChanged;
					// Remove item from internal collection
				}
			}
		}
		private void OnWorkItemChanged(object sender, PropertyChangedEventArgs e)
		{
 			// Modify existing item in internal collection
		}
