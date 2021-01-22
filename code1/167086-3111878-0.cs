    using System;
    using System.Collections.Generic;
    
    enum Foo
    {
        Bar = 0,
        Baz
    }
    
    public class Test
    {
        static void Main()
        {
            List<Int32> transmitIndex = new List<Int32>((Int32)Foo.Baz);
        }
    }
