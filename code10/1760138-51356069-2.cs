    // We read Cat from request body
    public class Cat
    {
        public string Name { get; set; }
        public string EyeColor { get; set; }
    }
    // AdoptionRequest from Query String or Route
    public class AdoptionRequest
    {
        public string From { get; set; }
        public string Days { get; set; }
    }
    // One class to merge them together
    [ModelBinder(BinderType = typeof(CatAdoptionEntityBinder))]
    public class CatAdoptionRequest
    {
        public Cat Cat { get; set; }
        public AdoptionRequest AdoptionRequest { get; set; }
    }
    public class CatAdoptionEntityBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Read Cat from Body
            var memoryStream = new MemoryStream();
            var body = bindingContext.HttpContext.Request.Body;
            var reader = new StreamReader(body, Encoding.UTF8);
            var text = reader.ReadToEnd();
            var cat = JsonConvert.DeserializeObject<Cat>(text);
            // Read Adoption Request from query or route
            var adoptionRequest = new AdoptionRequest();
            var properties = typeof(AdoptionRequest).GetProperties();
            foreach (var property in properties)
            {
                var valueProvider = bindingContext.ValueProvider.GetValue(property.Name);
                if (valueProvider != null)
                {
                    property.SetValue(adoptionRequest, valueProvider.FirstValue);
                }
            }
            // Merge
            var model = new CatAdoptionRequest()
            {
                Cat = cat,
                AdoptionRequest = adoptionRequest
            };
            bindingContext.Result = ModelBindingResult.Success(model);
            return;
        }
    }
    // Controller
    [HttpPost()]
    public bool Post([CustomizeValidator]CatAdoptionRequest adoptionRequest)
    {
        return ModelState.IsValid;
    }
    public class CatAdoptionRequestValidator : AbstractValidator<CatAdoptionRequest>
    {
        public CatAdoptionRequestValidator()
        {
            RuleFor(profile => profile.Cat).NotNull();
            RuleFor(profile => profile.AdoptionRequest).NotNull();
            RuleFor(profile => profile.Cat.Name).NotEmpty();
        }
    }
    // and in our Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddFluentValidation();
        services.AddTransient<IValidator<CatAdoptionRequest>, CatAdoptionRequestValidator>();
    }
