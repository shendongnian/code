    extern alias SystemCore;
    
    using System;
    using SystemCore::System.Linq;
    
    static class Test
    {
        static void Main()
        {
            var names = new[] { "Larry", "Curly", "Moe" };
            
            var result = names.Where(x => x.Length > 1);
        }
    }
