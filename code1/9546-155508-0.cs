     public static bool operator ==(Region r1, Region r2)
        {
            if (object.ReferenceEquals(r1, null))
            {
                return false;
            }
            if (object.ReferenceEquals(r2, null))
            {
                return false;
            }
    
            return (r1.Cmr.CompareTo(r2.Cmr) == 0 && r1.Id == r2.Id);
        }
