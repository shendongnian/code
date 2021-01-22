    var collection = new SortingObservableCollection<MyViewModel, int>(Comparer<int>.Default, model => model.IntPropertyToSortOn);
    collection.Add(new MyViewModel(3));
    collection.Add(new MyViewModel(1));
    collection.Add(new MyViewModel(2));
    // At this point, the order is 1, 2, 3
    collection[0].IntPropertyToSortOn = 4; // As long as IntPropertyToSortOn uses INotifyPropertyChanged, this will cause the collection to resort correctly
