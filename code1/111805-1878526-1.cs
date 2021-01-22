    public class Validator
    {
      public bool IsValidName(string name);
    }
    
    class Patient
    {
      private Validator validator = new Validator();
      public string FirstName
      {
         set
         {
             if (validator.IsValidName(value)) ... else ...
         }
      }
    }
