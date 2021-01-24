    public class MyClass
    {
       private readonly ReadOnlyObservableCollection<MyType> _myItems;
       public MyClass()
       {
          base.Items
             // This makes a IObservable<IChangeSet<T>> which describes the changes
             .ToObservableChangeSet()
             // this will make sure you get the MyType
             .Filter(x => x is MyType)
             // This will convert them into MyType instances.
             .Transform(x => (MyType)x)
             // This is mostly only needed if your source allows multi threading
             .ObserveOn(RxApp.MainThreadScheduler)
             // This will make your _myItems keep in sync with what's done above
             .Bind(out _myItems)
             .Subscribe();
       }
    
       public ReadOnlyObservableCollection<MyType> MyItems => _myItems;
    }
