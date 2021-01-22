    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    class Test
    {
        [DllImport("libaiousb")]
        static extern uint QueryDeviceInfo(uint deviceIndex,
            ref uint pid, ref uint nameSize, StringBuilder name,
            ref uint dioBytes, ref uint counters);
        static void Main()
        {
            uint deviceIndex = 100;
            uint pid = 101;
            uint nameSize = 102;
            StringBuilder name = new StringBuilder("Hello World");
            uint dioBytes = 103;
            uint counters = 104;
            uint result = QueryDeviceInfo(deviceIndex,
                ref pid, ref nameSize, name,
                ref dioBytes, ref counters);
            Console.WriteLine(deviceIndex);
            Console.WriteLine(pid);
            Console.WriteLine(nameSize);
            Console.WriteLine(dioBytes);
            Console.WriteLine(counters);
            Console.WriteLine(result);
        }
    }
