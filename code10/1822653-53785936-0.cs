    var test2NotInTest1 = test1.Except(test2, new ErrorsComparer()); 
    class ErrorsComparer : IEqualityComparer<Errors>
    {
        public bool Equals(Errors x, Errors y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the products' properties are equal.
            return x.ID == y.ID && x.Occurrence == y.Occurrence;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Errors e)
        {
            if (Object.ReferenceEquals(e, null)) return 0;
    
            int hashID = e.ID == null ? 0 : e.ID.GetHashCode();
            int hashO = e.Occurrence.GetHashCode();
    
            //Calculate the hash code for the product.
            return hashID ^ hashO;
        }
    }
