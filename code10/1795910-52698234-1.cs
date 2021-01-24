    class Person
    {
    }
    class Employee: Person
    {
    }
    
    class PersonRegister
    {
       GetJobTitle(Employee e) {return e.JobTitle;}
    }
    
    class DeriverRegister: PersonRegister
    {
      GetJobTitle(Person p)  //contravariance, using less derived type, cannot be done in C#
    }
