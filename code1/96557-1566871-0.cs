    class Something : INotifyPropertyChanged
    {
          public int TestID 
          {
               get { return testId; }
               set 
               {
                    if (testId != value)
                    {
                         testId = value;
                         RaisePropertyChangedEvent("TestID");
                    }
               }
          }
     }
