    class Example : ObservableObject
    {
      //propfull
      private string name;
      public string Name
      {
        get {return name;}
        set 
        {
          name = value;
          OnPropertyChanged("Name");
        }
      }
    }
