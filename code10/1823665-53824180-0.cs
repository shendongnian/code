    [HttpGet]
    public ActionResult Example()
        {
            var model = new ExampleViewModel();
            return View(model);
        }
    [HttpPost]
    public ActionResult Example(ExampleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Process the model as you wish...
            return RedirectToAction(nameof(AnotherAction));
        }
