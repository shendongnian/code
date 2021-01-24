    try using this i will help
    
        public class IA
        {
           public static void Main()
           {
              foreach (var t in typeof(IA).Assembly.GetTypes()) {
                 Console.WriteLine("{0} derived from: ", t.FullName);
                 var derived = t;
                 do { 
                    derived = derived.BaseType;
                    if (derived != null) 
                       Console.WriteLine("   {0}", derived.FullName);
        
                 } while (derived != null);
                 Console.WriteLine(); 
              } enter code here
           }
