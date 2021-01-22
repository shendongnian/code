    using System;
    class Program
    {
        static void Main(String[] args)
        {
            checked // Yes, it works without overflow!
            {
                Int32 original = Int32.MaxValue;
                Int16[] result = GetShorts(original);
                Console.WriteLine("Original int: {0:x}", original);
                Console.WriteLine("Senior Int16: {0:x}", result[1]);
                Console.WriteLine("Junior Int16: {0:x}", result[0]);
                Console.ReadKey();
            }
        }
        static unsafe Int16[] GetShorts(Int32 value)
        {
            byte[] buffer = new byte[4];
            fixed (byte* numRef = buffer)
            {
                *((Int32*)numRef) = value;
                if (BitConverter.IsLittleEndian)
                    return new Int16[] { *((Int16*)numRef), *((Int16*)numRef + 1) };
                return new Int16[] { 
                    (Int16)((numRef[0] << 8) | numRef[1]),  
                    (Int16)((numRef[2] << 8) | numRef[3])
                };
            }
        }
    }
