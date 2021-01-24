    using System;
    namespace Demo
    {
        [Flags]
        enum Status
        {
            None     = 0,
            Status1  = 1,
            Status2  = 2,
            Status3  = 4,
            Status4  = 8,
            Status5  = 16,
            Status6  = 32,
            Status7  = 64,
            Status8  = 128,
            Status9  = 256,
            Status10 = 512,
            Status11 = 1024
        }
        class Program
        {
            static void Main()
            {
                Status s = (Status)1035;
                Console.WriteLine(s); // "Status1, Status2, Status4, Status11"
                if (s.HasFlag(Status.Status4))               // "Status 4 is set"
                    Console.WriteLine("Status4 is set");
                else
                    Console.WriteLine("Status4 is not set");
                if (s.HasFlag(Status.Status3))               // "Status 3 is not set"
                    Console.WriteLine("Status3 is set");
                else
                    Console.WriteLine("Status3 is not set");
            }
        }
    }
