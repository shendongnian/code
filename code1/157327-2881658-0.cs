    using System;
    
    class Program {
        static unsafe void Main(string[] args) {
            var buf = new Buffer72();
            Console.WriteLine(buf.bs[8]);
            Console.ReadLine();
        }
    }
    public struct Buffer72 {
        public unsafe fixed byte bs[7];
    }
