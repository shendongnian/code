    public ActionResult ViewCarpets()
    {
    
            IEnumerable<SelectListItem> Qualities = context.Qualities.Select(c => new SelectListItem
            {
                Value = c.Quality_Id.ToString(),
                Text = c.QName
            });
            IEnumerable<SelectListItem> Suppliers = context.Suppliers.Select(c => new SelectListItem
            {
                Value = c.Supplier_Id.ToString(),
                Text = c.SName
            });
            IEnumerable<SelectListItem> Designs = context.Design.Select(c => new SelectListItem
            {
                Value = c.Design_Id.ToString(),
                Text = c.DName
            });
            ViewBag.Quality_Id = Qualities;
            ViewBag.Supplier_Id = Suppliers;
            ViewBag.Design_Id = Designs;
            var products = GetProducts(); // whatever you need to do to get a list of products, database call etc.
            return View("ViewCarpets", model: products);
    }
