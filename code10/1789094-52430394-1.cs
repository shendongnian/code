    using System.Collections.Generic;
    using System.Linq;
    list.GroupBy(x => x.Location, new CustomComparer())...
    
    public class CustomComparer : IEqualityComparer<LocationType>
    {
        public bool Equals(LocationType A, LocationType B)
        {
            //return true if A is close enough to B
        }
    }
