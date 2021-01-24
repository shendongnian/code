    public ObservableCollection<Person> People { get; set; } = new 
    ObservableCollection<Person>();
    var p = new Person();
    p.DateTime = DateTime.Now
    People.Add(p);
