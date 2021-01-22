    class Person : IComparable<Person>, IComparable
    {
      public int Age { get; set; }
    
      public int CompareTo(Person other)
      {
        // Should be a null check here...
        return this.Age.CompareTo(other.Age);
      }
    
      public int CompareTo(object obj)
      {
        // Should be a null check here...
        var otherPerson = obj as Person;
        if (otherPerson == null) throw new ArgumentException("...");
        // Call the generic interface's implementation:
        return CompareTo(otherPerson);
      }
    }
