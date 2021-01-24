    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (this.HasContact)
        {
            Validator.TryValidateProperty(this.Contact,
                new ValidationContext(this, null, null) { MemberName = "Contact" },
                results);
        }
        return results;
    }
