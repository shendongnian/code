    public class MyBaseClass : IEquatable<MyBaseClass>
    {
      public string name = "";
      public bool Equals(MyBaseClass other)
      {
        return other != null &&
               name == other.name;
      }
    }
