    public class Model: IValidatableObject
    {
        public List<Thing> Things;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           //your validation logic here
        }
    }
