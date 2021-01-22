    public List<Person> MyPersonDataSource {get; private set; }
    
    private void BuildGridData(){
    
      System.Windows.Data.CollectionViewSource personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
    
      this.MyPersonDataSource = new List<Person>();
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
      personViewSource.Source = this.MyPersonDataSource;    
    }
