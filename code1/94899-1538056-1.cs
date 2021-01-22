    public struct YourClass
    {
        public int Value;
    
       public static YourClass operator +(YourClass yc1, YourClass yc2) 
       {
          return new YourClass() { Value = yc1.Value + yc2.Value };
       }
    
    }
