    public class YourClass
    {
        public int Value {get; set;}
    
       public static YourClass operator +(YourClass yc1, YourClass yc2) 
       {
          return new YourClass() { Value = yc1.Value + yc2.Value };
       }
    
    }
