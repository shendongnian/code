    public class Foo
    {
       IService _service;
       public Foo(IService service)
       {
          _service = service;
       }
       public void SaveAccount(int accountNumber)
       {
           _service.Save_accountNumber);
    
       }
    }
    public class Program
    {
         public static void Main()
         {
            Foo foo = new Foo(new Service());
            foo.Save(1234);
         }
    }
