    public class CustomObjectValidator : IObjectModelValidator
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly IList<IModelValidatorProvider> _validatorProviders;
        private ValidatorCache _validatorCache;
        private CompositeModelValidatorProvider _validatorProvider;
        public CustomObjectValidator(IModelMetadataProvider modelMetadataProvider, IList<IModelValidatorProvider> validatorProviders)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _validatorProviders = validatorProviders;
            _validatorCache = new ValidatorCache();
            _validatorProvider = new CompositeModelValidatorProvider(validatorProviders);
        }
        public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
        {
            var visitor = new ValidationVisitor(
                actionContext,
                _validatorProvider,
                _validatorCache,
                _modelMetadataProvider,
                validationState);
            var metadata = model == null ? null : _modelMetadataProvider.GetMetadataForType(model.GetType());
            visitor.ValidateComplexTypesIfChildValidationFails = ValidateComplexTypesIfChildValidationFails;
            visitor.Validate(metadata, prefix, model);
        }
        public bool ValidateComplexTypesIfChildValidationFails { get; set; }
    }
