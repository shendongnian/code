    [ReturnableActionFilter]
    [BreadcrumbActionFilter(Text = "Invoices")]
    [ClaimsAuthorize("InvoicesController", "Read")]
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        return View(await IndexModel_Get());
    }
