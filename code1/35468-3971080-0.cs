    public static class EnumerableExtensions { 
      public static string Join<T>(this IEnumerable<T> self, string separator) {  
        return String.Join(separator, self.Select(e => e.ToString()).ToArray()); 
      } 
    } 
    public class Person {  
      public string FirstName { get; set; }  
      public string LastName { get; set; }  
      public override string ToString() {
        return string.Format("{0} {1}", FirstName, LastName);
      }
    }  
    // ...
  
    List<Person> people = new List<Person>();
    // ...
    string fullNames = people.Join(", ");
    string lastNames = people.Select(p => p.LastName).Join(", ");
