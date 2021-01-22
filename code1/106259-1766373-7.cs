    public class DataErrorInfoModelPropertyValidatorProvider : ModelValidatorProvider
    {
        // Methods
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var validators = new List<ModelValidator>();
            validators.Add(new DataErrorInfoPropertyModelValidator(metadata, context));
            return validators;
        }
        internal sealed class DataErrorInfoPropertyModelValidator : ModelValidator
        {
            // Methods
            public DataErrorInfoPropertyModelValidator(ModelMetadata metadata, ControllerContext controllerContext)
                : base(metadata, controllerContext)
            {
            }
            public override IEnumerable<ModelValidationResult> Validate(object container)
            {
                if (container != null)
                {
                    IDataErrorInfo info = container as IDataErrorInfo;
                    if (info != null)
                    {
                        string str = info[Metadata.PropertyName];
                        if (!string.IsNullOrEmpty(str))
                        {
                            ModelValidationResult[] resultArray = new ModelValidationResult[1];
                            ModelValidationResult result = new ModelValidationResult();
                            result.Message = str;
                            resultArray[0] = result;
                            return resultArray;
                        }
                    }
                }
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
