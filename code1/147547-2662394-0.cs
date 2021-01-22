     public class Person { } 
     public class Teacher : Person { } 
     public class MailingList
     {
           public void Add( IEnumerable<Person> people ) { ... }
     }
     public class School
     {
           public IEnumerable<Teacher> GetTeachers() { ... }
     }
     ...
     var teachers = school.GetTeachers();
     var mailingList = new MailingList();
     mailingList.Add( teachers );
