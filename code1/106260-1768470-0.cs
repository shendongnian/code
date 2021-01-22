    internal sealed class DataErrorInfoPropertyModelValidator : ModelValidator
    {
        public DataErrorInfoPropertyModelValidator(ModelMetadata metadata, ControllerContext controllerContext)
            : base(metadata, controllerContext)
        {
        }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (Metadata.Model != null)
            {
                var castContainer = container as IDataErrorInfo;
                if (castContainer != null)
                {
                    string errorMessage = castContainer[Metadata.PropertyName];
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        return new[] { new ModelValidationResult { Message = errorMessage } };
                    }
                }
            }
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
