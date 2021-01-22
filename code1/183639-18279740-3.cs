         using InternalTest;   
         namespace InternalTest1   ----This namespace in assembly Two
         {
           Public class A1:B
            {
               Public void GetInternalValue()
              {                     return x; //error can't access because this is internal
              }
  
              Public void GetProtectedValue()
              {
                    return y;//Work because it's protected
              }
          }
           public class C
           {
          
           }
      
        }
