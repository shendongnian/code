    using System;
    using System.Collections.Generic;
    
    class MyObj : IComparable<MyObj>
    {
        public string Name { get; set; }
        public string ObjectID { get; set; }
    
        public int CompareTo(MyObj other)
        {
            if ((this.Name.CompareTo(other.Name) == 0) &&
                (this.ObjectID.CompareTo(other.ObjectID) == 0))
            {
                return 0;
            }
            return -1;
        }
    }
