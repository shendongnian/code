    public class DistinctType1IdValidation : ValidationAttribute
    {
        private readonly DistinctValidator<Type1> validator;
        public DistinctIdValidation()
        {
            validator = new DistinctValidator<Type1>(x=>x.Id);
        }
        public override bool IsValid(object value)
        {
            return validator.IsValid(value);
        }
    }
    public class DistinctType2NameValidation : ValidationAttribute
    {
        private readonly DistinctValidator<Type2> validator;
        public DistinctType2NameValidation()
        {
            validator = new DistinctValidator<Type2>(x=>x.Name);
        }
        public override bool IsValid(object value)
        {
            return validator.IsValid(value);
        }
    }
    ...
    [DataMember, DistinctType1IdValidation ]
    public Type1[] Items { get; set; }
    [DataMember, DistinctType2NameValidation ]
    public Type2[] Items { get; set; }
