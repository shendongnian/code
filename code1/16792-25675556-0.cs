    ObservableCollection<MyClass> collection = ...;
    var changes = collection.AsCollectionNotifications<MyClass>();
    var itemChanges = changes.PropertyChanges();
    var deepItemChanges = changes.PropertyChanges(
      item => item.ChildItems.AsCollectionNotifications<MyChildClass>());
