    public Collection<Person> MyPersonDataSource {get; private set; }
    
    public MyWindowsConstructor() {
        //build the grid data before you initialize the window, as the PersonDataSource
        //does not implement NotifyPropertyChanged, if you build the data afterwards
        //the binding won't be updated
        BuildGridData();
        InitializeComponent();
    } 
    private void BuildGridData(){
    
      this.MyPersonDataSource = new Collection<Person>();
      Person p = new Person();
    
      string[] str = new string[] { "Stacey", "Olivia", "Dylan", "Lauryn", "Beth", "Caitlin" };
      var data = from s in str
                 select s;
      Person pers;
      foreach (var d in data)
      {
         pers = new Person();
         pers.Name = d;
         pers.Age = 22;
         this.MyPersonDataSource.Add(pers);
      }
    }
