    [Route("/Home/Index")]
    [Route("/Home/Index/{Category}")]
    [Route("/Home/Index/{Category}/{Type}")]
    public IActionResult Index(HomeModel model) {
        // Issue is here
        // for url: home/index/accessories/test
        // "Category" is cleared if it is not valid "type"
        // but still "Accessories" remains selected in the drop down
        if (model.Type != "Electronics" && model.Type != "Furniture") {
            model.Category = string.Empty;
        }
        ModelState.Clear();
        return View(new HomeModel() { Category = model.Category, Type = model.Type });
    }
