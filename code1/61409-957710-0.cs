    public class Address : IEqualityComparer<Address>
    {        
        //
        // member declarations
        //
    
        bool IEqualityComparer<Address>.Equals(Address x, Address y)
        {
            // implementation here
        }
        int IEqualityComparer<Address>.GetHashCode(Item obj)
        {
            // implementation here
        }
    }
