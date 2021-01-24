        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(EstimatedStartDate < EstimatedEndDate))
                yield return new ValidationResult(
                    "StartDateBeforeEndDate|The estimated start date should be smaller than the end date.",
                    new[] {"BoardAbstractBase"});
            if (!this.RepoValidate()){ ... }
        }
