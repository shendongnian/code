    //ifs expanded a bit for readability
     public static bool operator ==(Region r1, Region r2)
        {
            if( (object)r1 == null && (object)r2 == null)
            {
               return true;
            }
            if( (object)r1 == null || (object)r2 == null)
            {
               return false;
            }        
            //btw - a quick shortcut here is also object.ReferenceEquals(r1, r2)
    
            return (r1.Cmr.CompareTo(r2.Cmr) == 0 && r1.Id == r2.Id);
        }
