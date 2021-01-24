    class NumberDoubles: IEqualityComparer<List<double>>
    {
        public bool Equals(List<double> x, List<double> y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            if (x.Count!= y.Count)
                return false;
    
            //Check whether the arrays' values are equal.
            for(int i = 0; i < x.Count; i++){
                if(x[i] != y[i])
                    return false;
            }
    
            // If got this far, arrays are equal
            return true;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(List<double> doubleArray)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(doubleArray, null)) return 0;
    
            //Calculate the hash code for the array
            int hashCode = 0;
            bool isFirst = true;
            foreach(int i in doubleArray){
                if(isFirst) {
                    hashCode = i;
                    isFirst = false;
                }
                else
                {
                    hashCode = hashCode ^ i;
                }
            }
            return hashCode;
        }
    }
    
