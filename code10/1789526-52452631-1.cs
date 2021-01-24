        private static void OnCommandsCollectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //add event handler to monitor the changes to this collection
            var @this = (CommandViewModelCollection)d;
            @this.CommandsCollection.CollectionChanged += @this.OnCommandsCollectionCollectionChanged;
            //de-attach from old one
            if (e.OldValue is ObservableCollection<CommandViewModel> oldValue)
                oldValue.CollectionChanged -= @this.OnCommandsCollectionChanged;
            //any code here to execute based on collection changes
        }
