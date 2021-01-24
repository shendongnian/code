    public class Person
    {
      public string Name { get; set; }
      public string Surname { get; set; }
      public Address Address { get; set; }
      public override string ToString()
      {
        return $"Name:{Name},Surname:{Surname},Line1:{Address?.Line1},Line2:{Address?.Line2}";
      }
    }
