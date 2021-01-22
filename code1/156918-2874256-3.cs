    namespace WebM.VP8
    {
        using System;
    
        using WebM.VP8.Native;
    
        public class Program
        {
            public static void Main()
            {
                using (var encoder = VP8Codec.CreateEncoder())
                {
                    Console.WriteLine(encoder.Encode());
                }
            }
        }
    }
