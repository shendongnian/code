     public async void Method1()
      {
        FinishedListener listner = new FinishedListener();
        await SomeClass.Init(listner);
        // Do something with "listner.Data.Response"
      }
