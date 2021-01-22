    using System;
    
    class Foo
    {
        public IComparable GetComparable()
        {
            // Either of these return statements
            // would be valid since both System.Int32
            return 4;
            // and System.String
            return "4";
            // implement System.IComparable
        }
    }
