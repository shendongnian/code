    public class DateValidation : ValidationRule 
        { 
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo) 
            { 
                ValidationResult result; 
                try 
                { 
                   Regex regex = new Regex(@"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");
                   DateTime? date;
   
                   //Verify whether date entered in dd/mm/yyyy format.
                   bool isValid = regex.IsMatch(value.ToString());
    
                   //Verify whether entered date is Valid date.       
                   isValid = isValid && DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out date);                                                                                                             
                   result = isValid ? new ValidationResult(true,null) : new ValidationResult(false,"Date wrongly entered");  
                }catch(Exception ) 
                { 
                    result = new ValidationResult(false,"Date wrongly entered"); 
                } 
                return result; 
            } 
        } 
