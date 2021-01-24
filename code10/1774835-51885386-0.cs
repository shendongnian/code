	public ActionResult Index()
	{
		var model = new ProductViewModel();
		return View(model);
	}
	[HttpPost]
	public ActionResult Index(ProductViewModel model)
	{
		if (model == null)
		{
			model = new ProductViewModel();
		}
		if (model.Products == null)
		{
			model.Products = new List<Product>();
		}
		model.Products.Add(new Product { Name = "Some Product", Amount = model.Products.Count + 1});
		return View(model);
	}
