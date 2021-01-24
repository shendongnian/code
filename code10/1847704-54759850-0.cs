    public class Base
    {
        public int Id {get;set;}
    }
    public class Region : Base
    {
    }
    
    public class Country : Base
    {
        public int RegionId {get;set;}
    }
    
    public class State : Base
    {
        public int CountryId {get;set;}
    }
    public class District : Base 
    {
        public int StateId {get;set;}
    }
