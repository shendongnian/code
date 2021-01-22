    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Foo
    {
        [Required(ErrorMessage = "the Bar is absolutely required :-)")]
        public string Bar { get; set; }
    }
    
    class Program
    {
        public static void Main()
        {
            var foo = new Foo();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(foo, null, null);
            if (!Validator.TryValidateObject(foo, context, results))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }
    }
