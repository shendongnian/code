    public class DemoViewModelValidatorAttribute : TypeFilterAttribute
    {
        public DemoViewModelValidatorAttribute() 
            : base(typeof(DemoViewModelValidator))
        {
        }
        internal class DemoViewModelValidator : BaseViewModelValidator<DemoViewModel>
        {
            private readonly ISomeService service;
            // dependencies are injected here (assuming you've registered them in the start up)
            public DemoViewModelValidator(ISomeService service) => this.service = service;
            public async override Task ValidateAsync(DemoViewModel model, ModelStateDictionary state)
            {
                if (await this.service.CheckSomethingAsync(model))
                    state.AddModelError(nameof(model.SomeProperty), $"Whoops!!!");
            }
        }
    }
