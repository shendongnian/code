    public class Example
    {
     public static void Main() 
     {
     int val1 = 0; //must be initialized 
     int val2; //optional
     
     Example1(ref val1);
     Console.WriteLine(val1); 
     
     Example2(out val2);
     Console.WriteLine(val2); 
     }
     
     static void Example1(ref int value) 
     {
     value = 1;
     }
     static void Example2(out int value) 
     {
     value = 2; 
     }
    }
     
    /* Output     1     2     
