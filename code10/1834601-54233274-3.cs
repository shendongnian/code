    public class CompanyFilter : ActionFilterAttribute
    {
        private readonly ErpSettings erpSettings;
        public CompanyFilter(IOptions<ErpSettings> erpSettings)
        {
            this.erpSettings= erpSettings.Value;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
                controller.ViewBag.ERPUrl = erpSettings.Url;
        }
    }
