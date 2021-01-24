    `[HttpPost]
    public JsonResult Create(CreateRMAVM vm)
    {
    try
    {
    if (vm.CustomerName != null && vm.vares != null)
    {
    vm.vares.Select(c => { c.CustomerName = vm.CustomerName; return c; 
    }).ToList();
    }`
