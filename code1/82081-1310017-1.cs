    public class PersonValidator: IValidator<Person>
    {
        public PersonValidator()
        {
            AddRule(p => p.FirstName).CannotBeNull().CannotBeEmpty();
            AddRule(p => p.LastName).CannotBeNull().CannotBeEmpty();
        }    
    
        public List<ValidationResult> Validate(Person p)
        {
            List<ValidationResult> results = new List<ValidationResult>();
    
            foreach (IValidatorRule<Person> rule in rules) // don't know where rules is, or what the AddRule method adds to...you'll need to figure that out
            {
                results = rule.Apply(p);
            }
    
            return results;
        }
    }
