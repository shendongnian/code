    using System;
    
    class Test
    {   
        static void Main(string[] args)
        {
            
            for(var i=0;;i=(i+1) % 126)
            {
                Console.Write((char)(i+32));
            }
        }
    }
