        public ActionResult ProductSelect(ProductViewModel productVM)
        {
            PopulateProducts();
            if (productVM.ProductIDs != null)
            {
                List<SelectListItem> selectedItems = ((IEnumerable<SelectListItem>)ViewBag.Lista)
                    .Where(p => productVM.ProductIDs.Contains(int.Parse(p.Value))).ToList();
                ViewBag.Message = selectedItems.Count.ToString(); //returns 0
                ViewBag.Message2 = ((IEnumerable<SelectListItem>)ViewBag.Lista).Count().ToString();//returns 0
            }
            return View(productVM);
        }
