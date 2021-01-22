    public MyClass 
    {
        public string Name {get; set;}
        public MyEnum Type {get; set;}
        public MyClass2 Child {get; set;}
    }
    public MyClass2
    {
        public int Age {get; set;}
        public DateTime MyDate {get; set;}
    }
    
    MyClass myClass = new MyClass()
    {
        Name = "Bruce",
        Type = MyEnum.Sometype,
        Child = new MyClass2()
        {
            Age = 18,
            MyDate = DateTime.Now()
        }
    };
    
    Dictionary<string, string> headers = new Dictionary<string, string>();
    headers.Add("Name", "CustomCaption_Name");
    headers.Add("Type", "CustomCaption_Type");
    headers.Add("Age", "CustomCaption_Age");
    GetPropertiesValues(myClass, headers)); // OUTPUT: {{"Name","Bruce"},{"Type","Sometype"},{"Age","18"}}
