    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "Ada",
                NickName = "A"
            };
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            //Should be a problem with the NickName
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string NickName { get; set; }
    }
    class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).SetValidator(new NameValidator());
            RuleFor(x => x.NickName).SetValidator(new NameValidator());
        }
    }
    public class NameValidator : AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(x => x).Must(x => x.Length > 1)
                .WithMessage("The name is not long enough");
        }
    }
