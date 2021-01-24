    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
             DateTime? nullableDate = null;
    
             bool output = CheckNull.IsNullable(nullableDate); // false
           
             Console.WriteLine(output );
        }
        
     public static class CheckNull
     {
       public static bool IsNullable<T>(T t) { return false; }
       public static bool IsNullable<T>(T? t) where T : struct { return true; }
     }
    }
