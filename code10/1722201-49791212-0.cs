    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Test
        {
            public string Time;
        }
        class Program
        {
            static void Main()
            {
                var Model = new List<Test>
                {
                    new Test{Time = "01:01:01"},
                    // null, // Uncomment this line to make it crash.
                    new Test{Time = null}, new Test{Time = "02:02:02"}
                };
                int result = Model.Sum(x => TimeSpan.Parse(x.Time ?? "00:00:00").Minutes);
                Console.WriteLine(result);
            }
        }
    }
