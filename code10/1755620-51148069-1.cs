    private ObservableCollection<MyClass> myClasses;
    public MainPage()
    {
        this.InitializeComponent();
        myClasses = new ObservableCollection<MyClass>();
        myClasses.Add(new MyClass { Name = "Nico", Complete = false });
        myClasses.Add(new MyClass { Name = "LIU", Complete = true });
        myClasses.Add(new MyClass { Name = "He", Complete = true });
        myClasses.Add(new MyClass { Name = "Wei", Complete = false });
        myClasses.Add(new MyClass { Name = "Dong", Complete = true });
        myClasses.Add(new MyClass { Name = "Ming", Complete = false });
        
        this.cvs.Source = myClasses;
        this.cvs.IsSourceGrouped = False;
    }
     
    
   
