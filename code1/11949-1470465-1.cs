    public class PositionDateComparer : IComparer<VehiclePosition>
    {
        public int Compare(VehiclePosition x, VehiclePosition y)
        {
            if (x.DateTime == DateTime.MinValue)
            {
                if (y.DateTime == DateTime.MinValue)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
    
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
    
            // If x is not null...
            //
            if (y.DateTime == DateTime.MinValue)
            // ...and y is null, x is greater.
            {
                return 1;
            }
    
            // ...and y is not null, compare the dates
            //
            if (x.DateTime == y.DateTime)
            {
                // x and y are equal
                return 0;
            }
    
            if (x.DateTime > y.DateTime)
            {
                // x is greater
                return 1;
            }
    
            // y is greater
            return -1;
        }
    }
