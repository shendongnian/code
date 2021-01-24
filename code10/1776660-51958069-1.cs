    // Result container.
    private class RadiusValidationResults
    {
       public bool IsSuccessful {get; private set;}
       public int Radius {get; private set;}
       public string FailureReason {get; private set;}
    
       private RadiusValidationResults()
       { }
    
       public static RadiusValidationResults Success(int result)
       {
          return new RadiusValidationResults { IsSuccessful = true, Radius = result };
        }
    
        public static RadiusValidationResults Failure(string failureReason)
        {
          return new RadiusValidationResults { FailureReason = failureReason };
        }
    }
    
    // Validation business logic.
    private static RadiusValidationResult ValidateRadius(string input)
    {
        if (string.IsNullOrEmpty(input)
            return RadiusValidationResult.Failure("You must enter a value.");
        
        int radius;
        
        if (!int.TryParse(strradius))
            return RadiusValidationResult.Failure("You must enter a valid number.");
        else if (intradius < 1)
            return RadiusValidationResult.Failure("Your number is out of range");
        
        return RadiusValidationResult.Success(radius);   
    }
