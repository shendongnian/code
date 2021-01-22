    using System;
    
    public class Test
    {
        static Test shared;
        
        string First { get; set; }
        
        string Second
        {
            set
            {
                Console.WriteLine("Setting second. shared.First={0}",
                                  shared == null ? "n/a" : shared.First);
            }
        }
        
        static void Main()
        {
            shared = new Test { First = "First 1", Second = "Second 1" };
            shared = new Test { First = "First 2", Second = "Second 2" };        
        }
    }
