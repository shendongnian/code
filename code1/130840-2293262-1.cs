    void DoBackgroundOperation(ObservableCollection<SomeType> col) {
      var dispatcher = Dispatcher.CurrentDispatcher;
      ThreadStart start = () => BackgroundStart(dispatcher, col);
      var t = new Thread(start);
      t.Start();
    }
    
    private static void BackgroundStart(
        Dispatcher dispatcher, 
        ObservableCollection<SomeType> col) {
      ...
      SomeType t = GetSomeTypeObject();
      Action del = () => col.Add(t);
      dispatcher.Invoke(del);
    }
