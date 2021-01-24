    class Person
    {
         public int Id {get; set;}
    
         // every Person has zero or more PersonGrades (one-to-many
         public virtual ICollection<Grade> Grades {get; set;}
         ... // other properties
    }
    class ExtendedPerson : Person
    {
         // inherits primary key and Grades from Person
         // every ExtendedPerson has zero or more Hobbies (one-to-many)
         public virtual ICollection<Hobby> Hobbies {get; set;}
         ...
    }
