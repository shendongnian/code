    public class House
    {
        public int number { get; set; }
        public string street { get; set; }
        public List<Apartment> apartments = new List<Apartment>();
    }
    public class Apartment
    {
        public int apt_number { get; set; }
        public int apt_Rooms { get; set; }
        public House house;
        public List<Resident> residents = new List<Resident>();
    }
    public class Resident
    {   public string name {get;set;}
        public string surname {get;set;}
        public Apartment apartment {get;set;}
    }
    
    
    
   
