     public class someclass
     {
          private Func A = ......
          private Func B = ......
          public void somemethod(type x)
          {
               if(x) this.A.Invoke();
               else this.B.Invoke();  
          }
     }
