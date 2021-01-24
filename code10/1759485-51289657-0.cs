    [Serializable]
    public class Car
    {
        public Driver Someone { get; set; } = new Driver { Id = 47 }; // I did this so I could identify the rows
        public List<Driver> Dudes { get; set; } = new List<Driver>(); 
    }
