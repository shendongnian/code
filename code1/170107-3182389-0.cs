    class Program
    {
        static void Main(string[] args)
        { 
            var invalidPerson = new Person { Name = "Very long name" };
            var validPerson = new Person { Name = "1" };
            var validator = new Validator<Person>();
            Console.WriteLine(validator.Validate(validPerson).Count);
            Console.WriteLine(validator.Validate(invalidPerson).Count);
            Console.ReadLine();
        }
    }
    public class Person
    {
        [StringLength(8, ErrorMessage = "Please less then 8 character")]
        public string Name { get; set; }
    }
    public class Validator<T> 
    {
        public IList<ValidationResult> Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, validationContext, validationResults, true);
            return validationResults;
        }
    }
