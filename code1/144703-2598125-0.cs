    [AutoMap(typeof(ProductModel), typeof(ProductViewModel))]
    public ActionResult Index(int id)
    {
        return View(_repository.GetById(id));
    }
