        public ActionResult addEditProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addEditProduct(EditProductModel model)
        {
            if (!model.HasCategories)
            {
                ModelState.AddModelError(string.Empty, "A category is required.");
                return View(new { id = model.P.ID });
            }
            if (!ModelState.IsValid())
            {
                return View(new { id = model.P.ID });
            }
        }
