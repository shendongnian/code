        public class Location
        {
            public string State { get; set;}
            public string Country { get; set;}
            public string City {get; set;}
       }
    
       public class LocationComparer : IEqualityComparer<Location>
       {
            public bool Equals(Location x, Location y)
            {
                 if(x == null || y == null) 
                     return false; 
    
                 return x.State.Equals(y.State) &&
                        x.Country.Equals(y.Country) && 
                        x.City.Equals(y.City);
            }
    
            public int GetHashCode(Location loc) 
            {
                 if(loc == null) 
                     return 0; 
                 
                 var value = 0; 
                 if(!string.IsNullOrEmpty(loc.Country))
                    value += loc.Country.Length; 
                   
                 if(!string.IsNullOrEmpty(loc.State))
                    value += loc.State.Length; 
                 
                 if(!string.IsNullOrEmpty(loc.City))
                     value += loc.City.Length;
    
                 return length * 89;
            }
       } 
       public class LocationMerger 
       {
             private readonly LocationComparer _comparer = new LocationComparer();
             public HashSet<Location> Locations { get; set;} 
             public LocationMerger()
             {
                  Locations = new HashSet<Location>(_comparer); // will use your custom comparer to check for unique Location instances 
             }
             public void AddChunks(IEnumerable<Location> locs)
             {
                   foreach(var l in locs)
                       Locations.Add(l); 
             }
       } 
