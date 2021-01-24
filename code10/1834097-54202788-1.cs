    public partial class Item : IValidatableObject
    {
        public int Total {get; set;}
    
        public int Accepted {get;set;}
    
        public int Rejected {get;set;}
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                List<ValidationResult> validationResults = new List<ValidationResult>();
                
                if(Accepted + Rejected > Total)
                {
                    validationResults.Add(new ValidationResult("The sum of Accepted and Rejected cannot greater than Total", new[] {""}));
                }
                
                return validationResults;
        }
    }
