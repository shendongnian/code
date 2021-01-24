    Public Class Person
    {
      Public Person()
      {
      }
          int id=0;--- Here we are doing default Initialization of object to handle default null values 
            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
    
            string name="";--- Here we are doing default Initialization of object to handle default null values 
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
    }
