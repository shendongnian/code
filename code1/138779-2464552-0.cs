    public interface IRegister 
    {
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }
        string EmailAddress { get; }        
        List<IPerson> Student { get; }
    }
    public static List<ValidationRule> GetValidationRules(List<IRegister> register)
    {
        List<ValidationRule> validationRules = new List<ValidationRule>();  
        foreach (IRegister myregister in register)
        {
            if (string.IsNullOrEmpty(myregister.FirstName))
                validationRules.Add(new ValidationRule("Reg", "Must have aFirst Name"));
            if (string.IsNullOrEmpty(myregister.LastName))
                validationRules.Add(new ValidationRule("Reg", "Must have a Last Name"));
            if (string.IsNullOrEmpty(myregister.EmailAddress))
                validationRules.Add(new ValidationRule("Reg", "Must have a Email Address"));
            foreach (IPerson person in myregister.Student) 
            {
                // Not sure what properties you want to check for because 
                // you didn't show us what the IStudent interface looks like
                // so I will just assume that the IStudent object has a  
                // property for EmailAddress as well
                 
                if (string.IsNullOrEmpty(person.EmailAddress))
                    validationRules.Add(new ValidationRule("Reg", "Student must have a Email Address"));
            }
        }
    }
