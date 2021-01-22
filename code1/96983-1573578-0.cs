    public class Child
    {
      public class Collection : ICollection<Child>
      {
      }
    }
    public class Parent
    {
      private Child.Collection children;
    }
