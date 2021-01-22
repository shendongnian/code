    public class Person : IEquatable<Person>
    { 
      public int Id; 
      public string Name; 
      ... 
    
      public bool Equals(Person other)
      {
        return other == null ? false : this.Id == other.Id;
      }
      public override int GetHashCode()
      {
        return this.Id.GetHashCode();
      }
    }
