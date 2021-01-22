    using System;
    
    class Test
    {
        static void Main()
        {
            Check((byte)10);
            Check((short)10);
            Check((ushort)10);
            Check((int)10);
            Check((uint)10);
        }
        
        static void Check(object o)
        {
            Console.WriteLine("Type {0} converted to UInt32: {1}",
                              o.GetType().Name, Convert.ToUInt32(o));
        }
    }
