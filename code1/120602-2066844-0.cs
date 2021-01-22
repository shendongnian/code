    abstract class Person {
     
    }
    
    class Programmer : Person {
     
    }
    var person = new Person();          // compile time error
    var programmer = new Programmer();  // ok
