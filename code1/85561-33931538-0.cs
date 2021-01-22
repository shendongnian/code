    using System.ComponentModel.DataAnnotations;
    public bool IsValidEmail(string source)
    {
        return new EmailAddressAttribute().IsValid(source);
    }
