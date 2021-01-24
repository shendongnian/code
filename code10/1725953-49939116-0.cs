    using System;
    using System.Threading.Tasks;
    
    public class Test
    {
        static void Main()
        {
            // Valid
            Func<Task> t1 = async () => { while(true); };
            
            // Valid
            Func<Task<int>> t2 = async () => { while(true); };
            
            // Valid
            Func<Task> t3 = async () => { while(false); };
            
            // Invalid
            Func<Task<int>> t4 = async () => { while(false); };
        }
    }
