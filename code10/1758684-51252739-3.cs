      public ObservableCollection<Appointments> Appointments = new ObservableCollection<Appointments>();
      private static object _lockobject = new object();
      public async void Load()
      {
            await Task.Run(() => { /*load stuff into the Appointments collection here */ });
            ///possibly more code to execute after the task is complete.
      }
      //in constructor or similar, this is REQUIRED because the collection is bound and must be synchronized for mulththreading operations
      BindingOperations.EnableCollectionSynchronization(YourCollection, _lockobject);
