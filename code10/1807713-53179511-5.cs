       public Information[] PMI(string Id)  
    {
        return new Information[]
        {
            new Information
            {
                Name = "First|Last",
                NameId = "1",
                Allowed = true,
                date = "Feb 1, 2018",
                EndTime = "1:00 PM",
                DateTime = "09:00"
				Settings = new Settings
				{
					id = 1,
					name = "TestName",
					maxValue = "1000"
				}
            },
            
        };
    }
_____________________________________________________________
    public class Information
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Allowed { get; set; }
        public string date { get; set; }
        public string EndTime { get; set; }
        public string DateTime { get; set; }
    	public Settings Settings {get; set;}
    }
    
    public class Settings
    {
        public string id { get; set; }
        public string name { get; set; }
        public string maxValue { get; set; }
    }
