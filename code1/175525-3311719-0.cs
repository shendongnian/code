       class Program
       {
          public class Student
          {
             public string firstName;
             public string lastName;
          }
          public class ScienceClass
          {
             public Student Student1, Student2, Student3;
          }
          static void Main(string[] args)
          {
             var student1 = new Student{firstName = "Bruce",
                                        lastName  = "Willis"};
             var student2 = new Student{firstName = "George",
                                        lastName  = "Clooney"};
             var student3 = new Student{firstName = "James",
                                        lastName  = "Cameron"};
             var sClass = new ScienceClass{Student1 = student1,
                                           Student2 = student2,
                                           Student3 = student3};
          }
       }
