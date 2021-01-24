        // Customer Input
        // GET: Addresses/Edit?guid=56A792FE-28D1-4D1D-8F59-21DE1EABA2FB
        // TO DO - Create Route in APP_Start RouteConfig for better looking link.
        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult UserEditAddress(Guid guid)
        {
            if (guid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressEdit addresses = db.AddressEdit.Find(guid);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            var model = new EditAddressViewModel();
            model.AddressUI = addresses.AddressUI;
            model.Line1 = addresses.Line1;
            model.Line2 = addresses.Line2;
            model.Country = addresses.Country;
            model.State = addresses.State;
            model.City = addresses.City;
            model.ZipCode = addresses.ZipCode;
            model.Countries = new SelectList(db.Countries, "CountryId", "CountryName", addresses.Country);
            model.States = new SelectList(db.States, "StateId", "StateName", addresses.State);
            model.Cities = new SelectList(db.Cities, "CityId", "CityName", addresses.City);
            return View(model);
        }
        // POST: Addresses/Edit?guid=56A792FE-28D1-4D1D-8F59-21DE1EABA2FB
        // TO DO - Create Route in APP_Start RouteConfig for better looking link.
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEditAddress([Bind(Include = "AddressUI,Line1,Line2,Country,State,City,ZipCode,CompanyId")] AddressEdit addresses)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            { 
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Customer", new { UserId = userId });
            }
            return View(addresses);
        }
        // Get States
        public JsonResult GetStates(string countryId)
        {
            int Id;
            Id = Convert.ToInt32(countryId);
            var states = from a in db.States where a.CountryId == Id select a;
            return Json(states);
        }
        // Get Cities
        public JsonResult GetCities(string stateId)
        {
            int Id;
            Id = Convert.ToInt32(stateId);
            var cities = from a in db.Cities where a.StateId == Id select a;
            return Json(cities);
        }
