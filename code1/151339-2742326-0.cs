    using System;
    using System.Collections.Generic;
    class Customer : IEquatable<Customer>
    {
        public int i;
        public string c1, c2;
        public Customer(int i, string c1, string c2)
        {
            this.i = i;
            this.c1 = c1;
            this.c2 = c2;
        }
    
        bool System.IEquatable<Customer>.Equals(Customer o)
        {
            if(o == null)
                return false;
            return this.i == o.i &&
                this.c1 == o.c1 &&
                this.c2 == o.c2;
        }
    
        public override int GetHashCode()
        {
            return i.GetHashCode() ^
                c1.GetHashCode() ^
                c2.GetHashCode();
        }
    }
    
