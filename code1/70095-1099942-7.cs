    using System;
    using System.IO;
    
    namespace EncodedNumbers
    {
        class Program
        {
            protected static void Write7BitEncodedInt(BinaryWriter bin, int value)
            {
                uint num = (uint)value;
                while (num >= 0x80)
                {
                    bin.Write((byte)(num | 0x80));
                    num = num >> 7;
                }
                bin.Write((byte)num);
            }
    
    
            static void Main(string[] args)
            {
                MemoryStream ms = new MemoryStream();
                BinaryWriter bin = new BinaryWriter(ms);
    
                for(int i = 1; i < 1000; i++)
                {
                    Write7BitEncodedInt(bin, i);
                }
    
                byte[] data = ms.ToArray();
                int size = data.Length;
                Console.WriteLine("Total # of Bytes = " + size);
    
                Console.ReadLine();
            }
        }
    }
 
