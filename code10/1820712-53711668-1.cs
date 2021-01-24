        public ActionResult New(Invoice InvoiceVM)
        {
    if (!ModelState.IsValid)
            { var model = new SomeModel {InvoiceVM =InvoiceVM;
               SomeData = _someService.GetData()};
                ModelState.AddModelError("INV_QUAN", "QUANTITY INVALID!");
                return View(model);
            }
