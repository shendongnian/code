    [HttpGet]
    public ActionResult Edit() {
        MyModel model = new MyModel();
        ...
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(MyModel model) {
        ...
        if (ModelState.IsValid) {
            // Save and redirect
            ...
            return RedirectToAction("Detail");
        }
        return View(model);
    }
