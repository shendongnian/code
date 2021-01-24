      public async void Method1()
      {
        FinishedListener listner = new FinishedListener();
        await Task.Run(()=>{ SomeClass.Init(listner); });  
        // Do something with "listner.Data.Response"
      }
