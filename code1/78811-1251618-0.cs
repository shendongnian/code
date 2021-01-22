    using System;
    
    class Test
    {
        public byte[] GiveMeBytes()
        {
            return new byte[2];
        }
        
        static void Main()
        {
            object obj = new Test();
            byte[] byteData = (byte[])obj.GetType().GetMethod("GiveMeBytes")
                                         .Invoke(obj, new object[0]);
            Console.WriteLine(byteData.Length); // Prints 2
        }
    }
