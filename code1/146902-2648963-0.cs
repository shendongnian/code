    public ActionResult Create()
        {
            var dbTimecard = new TimecardDbDataContext();
            IEnumerable<SelectListItem> stateProvinces = dbTimecard.StateProvinces.Select(p => new SelectListItem
            {
                Value = p.StateProvinceId.ToString(),
                Text = p.Name
            });
            ViewData["StateProvince"] = stateProvinces;
            return View();
        } 
