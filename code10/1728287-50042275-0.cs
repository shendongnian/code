    public class DataValidator : AbstractValidator<Data>
        {
            public DataValidator()
            {
                RuleFor(d => d.Ids)
                    .NotNull() //validates whether Ids collection is null
                    .NotEmpty() //validates whether Ids collection is empty
                    .SetCollectionValidator(new GuidValidator()); //validates each element inside Ids collection using GuidValidator
            }
        }
