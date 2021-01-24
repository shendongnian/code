    public ICommand MyTestCommand
    {
        get
        {
           return new MvxAsyncCommand(async () =>
           {
             // the following should should Loading for 3 seconds
              using (this._dialogs.Loading("Loading..."))
              {
                 await Task.Delay(TimeSpan.FromSeconds(3));
              }
           });
        }
     }
