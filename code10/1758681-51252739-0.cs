      public ObservableCollection<Appointments> Appointments = new ObservableCollection<Appointments>();
      private static object _lockobject = new object();
      public void Load()
      {
            Task.Run(async () => { /*load stuff into the Appointments collection here */ });
      }
      //in constructor or similar, this is REQUIRED because the collection is bound and must be synchronized for mulththreading operations
      BindingOperations.EnableCollectionSynchronization(YourCollection, _lockobject);
