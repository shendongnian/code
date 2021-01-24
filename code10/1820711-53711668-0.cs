        public ActionResult New(SomeModel model)
        {
    if (!ModelState.IsValid)
            {
                model.SomeData = _someService.GetData();
                ModelState.AddModelError("INV_QUAN", "QUANTITY INVALID!");
                return View(model);
            }
