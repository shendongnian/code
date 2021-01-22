    public class PersonValidator : IValidator<Person>
        {
            List<Func<Person,bool>> validationRules = new List<Func<Person,bool>>();
        public PersonValidator()
        {
            AddRule( p => IsNullOrEmpty(p.FirstName)).AddRule(p1 => CheckLength(p1.FirstName));
        }
        PersonValidator AddRule(Func<Person,bool> rule)
        {
            this.validationRules.Add(rule);
            return this;
        }
        private bool IsNullOrEmpty(String stringToCheck)
        {
            return String.IsNullOrEmpty(stringToCheck);
        }
        private bool CheckLength(String stringToCheck)
        {
            return (String.IsNullOrEmpty(stringToCheck) ? false : stringToCheck.Length < 3);
        }
        
        #region IValidator<Person> Members
        public bool Validate(Person obj)
        {
            return validationRules.Select(x => x(obj)).All(result => result == false);
        }
        #endregion
    }
            Person test = new Person() { FirstName = null };
            Person test1 = new Person() { FirstName = "St" };
            Person valid = new Person() { FirstName = "John" };
            PersonValidator validator = new PersonValidator();
            Console.WriteLine("{0} {1} {2}", validator.Validate(test), validator.Validate(test1), validator.Validate(valid));
