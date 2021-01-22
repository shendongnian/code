    class Base
    {
    }
    
    class AB : Base
    {
    
    }
    class AC : Base { }
        
    class Program
    {
       static Base GetObject()
       {
           return null;
       }
       static void Main(string[] args)
       {
           Base B = GetObject();
           if (B is AB)
           {
              AB DevClass =(AB) B;
           }
       }
    
           
    }
}
