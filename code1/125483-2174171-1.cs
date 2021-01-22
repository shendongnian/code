    public interface  InterfaceOne {
      void SomeMethod();
    }
    public interface InterfaceTwo {
      void SomeMethod();
    }
    public class Impl : InterfaceOne, InterfaceTwo {
      public void InterfaceOne.SomeMethod() {Console.WriteLine("One");}
      public void InterfaceTwo.SomeMethod() {Console.WriteLine("Two");}
    }
