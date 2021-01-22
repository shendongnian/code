    public class Person{
      public string Name {get;set;}
      public int Age {get;set;}
    }
    // and use it as follows in your functions
    var person1 = new Person() {
      Name = "Fred",
      Age = 21,
    };
    // again, to demonstrate different syntax to do same thing
    var person2 = new Person();
    person2.Name = "Danny";
    person2.Age = 2;
    person2.Age = "x";  // won't compile - expects int, hence safer
