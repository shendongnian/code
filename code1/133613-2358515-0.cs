    using System;
    
    class Test
    {
        static void Main()
        {
            OldMethod();
            BadMethod();
        }    
        
        [Obsolete("Use something else instead")]
        static void OldMethod() {}
        
        [Obsolete("This would destroy your machine!", true)]
        static void BadMethod() {}
    }
