	IDisposable subscription =
		Observable
			.FromEventPattern
				<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
					x => MyList.CollectionChanged += x,
					x => MyList.CollectionChanged -= x)
			.Where(x => x.EventArgs.Action == NotifyCollectionChangedAction.Add)
			.SelectMany(x => x.EventArgs.NewItems.Cast<MyCustomClass>())
			.SelectMany(x => x.OnPropertyChange(nameof(x.MyCustomProperty)))
			.Subscribe(_ => { });
