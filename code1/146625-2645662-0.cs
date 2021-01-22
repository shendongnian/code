    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    
    	public Class1(int id, string name, DateTime birthday)
    	{
            ID = id;
            Name = name;
            Birthday = birthday;
    	}
    }
    
    public class Class2 : Class1
    {
        public string Building { get; set; }
        public int SpotNumber { get; set; }
    	public Class2(string building, int spotNumber, int id, 
            string name, DateTime birthday) : base(id, name, birthday)
    	{
            Building = building;
            SpotNumber = spotNumber;
    	}
    }
    
    public class Class3
    {
    	public Class3()
    	{
            Class2 c = new Class2("Main", 2, 1090, "Mike Jones", DateTime.Today);
    	}
    }
