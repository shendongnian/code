    public class Person : IEquatable<Person>
    {
      public override int GetHashCode()
      {
        return PersonId.GetHashCode();
      }
    
      public override bool Equals(object obj)
      {
        var that = obj as Person;
        if (that != null)
        {
          return Equals(that);
        }
        return false;
      }
    
      public bool Equals(Person that)
      {
        return this.PersonId == that.PersonId;
      }
    }
