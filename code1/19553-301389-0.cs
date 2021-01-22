    public class BErrorWrapper : I1, I2, I3{
       ...
       public int DoSomeWork(int num){
          try
          {
             return B.DoSomeWork(num);
          }
          catch(MyLibException e)
          {
             if (FailWithExceptions) throw;
             return C.DoSomeWOrk(num);
          }
       }
       ...
    }
