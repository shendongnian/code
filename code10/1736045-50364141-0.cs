    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (Data data in Data.input)
                {
                    Data.Print(data);
                    Data results = Data.Unpack(Data.Pack(data));
                    Data.Print(results);
                }
                Console.ReadLine();
            }
        }
        public class Data
        {
            public static List<Data> input = new List<Data>() {
                new Data() { firstBool = true, firstFloat = 0.2345F, secondFloat = 0.432F,   firstInt = 12},
                new Data() { firstBool = true, firstFloat = 0.3445F, secondFloat = 0.432F,   firstInt = 11},
                new Data() { firstBool = false, firstFloat = 0.2365F, secondFloat = 0.432F,   firstInt = 9},
                new Data() { firstBool = false, firstFloat = 0.545F, secondFloat = 0.432F,   firstInt = 8},
                new Data() { firstBool = true, firstFloat = 0.2367F, secondFloat = 0.432F,   firstInt = 7}
            };
            public bool firstBool { get; set; }
            public float firstFloat {get; set; } //(0.0 to 1.0)  
            public float secondFloat {get; set; } //(0.0 to 1.0)  
            public int firstInt { get; set; } //(0 to 10,000)
            public static byte[] Pack(Data data)
            {
                byte[] results = new byte[4];
                results[0] = (byte)((data.firstBool ? 0x80 : 0x00) | (byte)(data.firstFloat * 128));
                results[1] = (byte)(data.secondFloat * 256);
                results[2] = (byte)((data.firstInt >> 8) & 0xFF);
                results[3] = (byte)(data.firstInt & 0xFF);
                return results;
            }
            public static Data Unpack(byte[] data)
            {
                Data results = new Data();
                results.firstBool = ((data[0] & 0x80) == 0) ? false : true;
                results.firstFloat = ((float)(data[0] & 0x7F)) / 128.0F;
                results.secondFloat = (float)data[1] / 256.0F;
                results.firstInt = (data[2] << 8) | data[3];
                return results;
            }
            public static void Print(Data data)
            {
                Console.WriteLine("Bool : '{0}', 1st Float : '{1}', 2nd Float : '{2}', Int : '{3}'",
                    data.firstBool,
                    data.firstFloat,
                    data.secondFloat,
                    data.firstInt
                    );
            }
        }
    }
