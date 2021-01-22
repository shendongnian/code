    [PagedInvoiceList(PageSize = 2, ListType = typeof (Invoice))]
    public ViewResult List() { ... }
    private class PagedInvoiceListAttribute : PagedListAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            DoActionExecuted<Invoice>(filterContext);
        }
    }
