    class BaseClass<T> where T : struct
    {
       public override void Execute(HttpContext context) 
       { 
            //Some code that's similar across CustomTypeOne, CustomTypeTwo etc 
       } 
     
       public void DoStuff() 
       { 
           //Same for all CustomTypes and can be part of a base class 
       } 
    
    }
    
    public class CustomTypeOne : BaseClass<int>
    {
    }
    public class CustomTypeTwo : BaseClass<long>
    {
    }
