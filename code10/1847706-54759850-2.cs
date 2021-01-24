    public class Base
    {
        public int Id {get;set;}
    }
    public class Region : Base
    {
    }
    
    public class Country : Base
    {
        public Region Region {get;set;}
        public int RegionId {get;set;}
    }
    
    public class State : Base
    {
        public Country Country {get;set;}
        public int CountryId {get;set;}
    }
    public class District : Base 
    {
        public State State {get;set;}
        public int StateId {get;set;}
    }
