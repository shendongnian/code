    class MyBoundaryObject : MarshalByRefObject {
        public void SomeMethod(AppDomainArgs ada) {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + "; executing");
            ada.myString = "working!";
        }
    }
    public class AppDomainArgs : MarshalByRefObject {
        public string myString { get; set; }
    }
    
     static class Program {
         static void Main() {
             AppDomain domain = AppDomain.CreateDomain("Domain666");
             MyBoundaryObject boundary = (MyBoundaryObject)
                  domain.CreateInstanceAndUnwrap(
                     typeof(MyBoundaryObject).Assembly.FullName,
                     typeof(MyBoundaryObject).FullName);
    
             AppDomainArgs ada = new AppDomainArgs();
             ada.myString = "abc";
             Console.WriteLine("Before: " + ada.myString);
             boundary.SomeMethod(ada);
             Console.WriteLine("After: " + ada.myString);         
             Console.ReadKey();
             AppDomain.Unload(domain);
         }
    }
