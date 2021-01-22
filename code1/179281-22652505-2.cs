    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.Enable)
        {
            // ...
            if (this.Prop1 > this.Prop2)
            {
                yield return new ValidationResult("Prop1 must be larger than Prop2");
            }
