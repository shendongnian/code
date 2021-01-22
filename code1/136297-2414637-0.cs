    public interface IValidateable {
      IEnumerable<string> Validate();
    }
    
    public class Person : IValidateable {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public Address HomeAddress { get; set; }
        
        public Person() {
          HomeAddress = new Address();
        }
        
        
        public IEnumerable<string> Validate() {
          var errors = new List<string>();
          if (string.IsNullOrEmpty(First))
            errors.Add("First name is required.");
          // And so on...
          return errors;
        }    
    }
    
    // Usage
    var p1 = new Person();
    var p2 = new Person {
        First = "Dmitriy"
      };
    
    if (p1.Validate().Any()) {
      // Do something with invalid object
    }
