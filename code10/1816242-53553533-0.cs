    public class Contains2RoutesConvention : IActionModelConvention
    {
        private readonly ISomeService someService;
        public Contains2RoutesConvention(ISomeService someService)
        {
            this.someService = someService;
        }
    
        public void Apply(ActionModel actionModel)
        {
            someService.DoSomething();
            ...
        }
    }
