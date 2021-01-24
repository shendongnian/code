    public bool IsValidEmailAddress(string email)
    {
        var emailValidator = new EmailAddressAttribute();
        return emailValidator.IsValid(email) && !String.EndsWith(".");
    }
