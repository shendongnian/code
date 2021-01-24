    using System;
    using System.Threading.Tasks;
    
    public class Test
    {
        static void Main()
        {
            // Valid
            Func<Task> t1 = async () => { while(true); };
            
            // Valid: end of lambda is unreachable, so it's fine to say
            // it'll return an int when it gets to that end point.
            Func<Task<int>> t2 = async () => { while(true); };
            
            // Valid
            Func<Task> t3 = async () => { while(false); };
            
            // Invalid
            Func<Task<int>> t4 = async () => { while(false); };
        }
    }
