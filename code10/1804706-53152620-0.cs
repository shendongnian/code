    public class ValidateItemAttribute : ParameterBindingAttribute
    {
            public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter) => new ItemIdValidation(parameter);
    }
      public class ItemIdValidation : HttpParameterBinding, IValueProviderParameterBinding
        {
            public HttpParameterBinding DefaultUriBinding;
            public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; }
            public ItemIdValidation(HttpParameterDescriptor desc) : base(desc)
            {
                var defaultUrl = new FromUriAttribute();
                this.DefaultUriBinding = defaultUrl.GetBinding(desc);
                this.ValueProviderFactories = defaultUrl.GetValueProviderFactories(desc.Configuration);
            }
    
    
            public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
            {
                return DefaultUriBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken).ContinueWith((tsk) =>
                {
                    var currentBoundValue = this.GetValue(actionContext)?.ToString();
                    var isMatched = currentBoundValue != null ? Regex.IsMatch(currentBoundValue, "^[0-9]*$") : false;
                    if (null != currentBoundValue && (!isMatched || currentBoundValue?.Length != 6))
                    {
                        var result = new
                        {
                            ErrorCode ="1",
                            ErrorDescription = "Invalid item id"
                        };
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, result, "application/json");
                    }
                }, cancellationToken);
            }
        }
