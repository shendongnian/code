    private readonly IGetItemsQuery getItemsQuery;
    public HomeController(IGetItemsQuery getItemsQuery) {
        this.getItemsQuery = getItemsQuery;
    }
    public async Task<IActionResult> Index() {
        var url = "....";
        var items = await getItemsQuery.Execute<MyItem>(url);
        return View(items);
    }
