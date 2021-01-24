    private ValidationResult IsValidata()
    {
        //validate the First Name textbox
        if (!IsPresent(txtFirst, "First Name"))
        {
            return new ValidationResult { 
                IsValid = false, 
                UserMessage = "Please enter a First Name"
            };
        }
        
        // rest of valiation rules here,
        // setting the UserMessage as appropriate
        // If no validation checks fail, then we are valid
        return new ValidationResult { IsValid = true };
    }
