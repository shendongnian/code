      // work on original instance
      ObservableCollection<TestObject> col = new ObservableCollectionEx<TestObject>();
      ((INotifyPropertyChanged)col).PropertyChanged += (s, e) => { Trace.WriteLine("Changed " + e.PropertyName); };
      var test = new TestObject();
      col.Add(test); // no event raised
      test.Info = "NewValue"; //Info property changed raised
      // working on explicit instance
      ObservableCollectionEx<TestObject> col = new ObservableCollectionEx<TestObject>();
      col.PropertyChanged += (s, e) => { Trace.WriteLine("Changed " + e.PropertyName); };
      var test = new TestObject();
      col.Add(test); // Count and Item [] property changed raised
      test.Info = "NewValue"; //no event raised
      
