    [HttpGet]
    public ActionResult Edit(int id) {
        var model = new EditModel();
        //...
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(EditModel model) {
        if (ModelState.IsValid) {
            product = repository.SaveOrUpdate(model);
            return RedirectToAction("Details", new { id = product.Id });
        }
        return View(model);
    }
    [HttpGet]
    public ActionResult Details(int id) {
        var model = new DetailModel();
        //...
        return View(model);
    }
