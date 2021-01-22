    public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            TestClass1 viewModel = new TestClass1();
            viewModel.FirstName = "TestFilter";
            filterContext.Controller.ViewData.Model = viewModel;
        }
