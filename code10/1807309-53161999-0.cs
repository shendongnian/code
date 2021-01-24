    public List<string> CheckErrors(List<string> errors)
    {
          if(errors == null)
          {
             throw new ArgumentNullException()
          }
          else if(errors.Count == 0)
          {
             throw new ArgumentException("At least one error must be present");
          }
    
     return errors;
    }
