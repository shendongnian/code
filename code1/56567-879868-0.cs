    using System;
    using System.Diagnostics;
    static class Program
    {
        static void Main()
        {
            byte[] buffer = BitConverter.GetBytes((uint)123);
            const int LOOP = 50000000;
            uint chk = 0;
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                chk += BitConverter.ToUInt32(buffer, 0);
            }
            watch.Stop();
            Console.WriteLine("BitConverter: " + watch.ElapsedMilliseconds
                + "ms, chk=" + chk);
    
            chk = 0;
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                chk += Bitwise(buffer);
            }
            watch.Stop();
            Console.WriteLine("Bitwise: " + watch.ElapsedMilliseconds
                + "ms, chk=" + chk);
    
            chk = 0;
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                chk += ReadLength(buffer);
            }
            watch.Stop();
            Console.WriteLine("ReadLength: " + watch.ElapsedMilliseconds
                + "ms, chk=" + chk);
    
            Console.ReadKey();
        }
        static uint Bitwise(byte[] buffer)
        {
            return ((uint)buffer[0])
                | (((uint)buffer[1]) << 8)
                | (((uint)buffer[2]) << 16)
                | (((uint)buffer[3]) << 24);
        }
        static uint ReadLength(byte[] buffer)
        {
            uint result = ((uint)buffer[3]) << 24;
            result += ((uint)buffer[2]) << 16;
            result += ((uint)buffer[1]) << 8;
            result += buffer[0];
            return result;
        }
    }
