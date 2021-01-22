    public int GetHashCode()
    {
        unchecked
        {
            int hashCode;
            
            // String properties
            hashCode = (hashCode * 397) ^ (str1!= null ? str1.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (str2!= null ? str1.GetHashCode() : 0);
            
            // int properties
            hashCode = (hashCode * 397) ^ intProperty;
            return hashCode;
        }
    }
