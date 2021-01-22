    public class NewFunctionalityClass : IClassB
    {
        public void SomeMethod()
        {
           //something else
        }
    }
    public TestClass()
    {
       public void ShowMethod()
       {
          var defaultObject = new ClassA();
          defaultObject.SomeMethod();  // default implementation
         var otherObject = new ClassA(new NewFunctionalityClass());
         otherObject.SomeMethod(); // here the new implementation will run
       }
    }
