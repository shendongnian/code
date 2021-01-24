    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetResultList(ResortDataJoinObj resDeals, int page =1)
        {
            if (ModelState.IsValid)
            {
                var resultsObj = from rd in _db.ResortData
                                  join ra in _db.ResortAvailability on rd.RecNo equals ra.RecNoDate
                                  where ra.TotalPrice < Int32.Parse(resDeals.priceHighEnd) && ra.TotalPrice > Int32.Parse(resDeals.priceLowEnd)
                                  select new ResortDealResultsObject
                                     {
                                           Name = rd.Name,
                                           ImageUrl = rd.ImageUrl,
                                           ResortDetails = rd.ResortDetails,
                                           CheckIn = rd.CheckIn,
                                           Address = rd.Address,
                                           TotalPrice = rd.TotalPrice
                                     };
                int pageSize = 3;
                var model = await PaginatedList<ResortDealResultsObject>.CreateAsync(resultsObj, page, pageSize);
                ResortDataJoinObj joinObj = new ResortDataJoinObj();
                joinObj.PageList = model;
                ViewBag.rowsReturned = true;
                return View(joinObj);
            }
            return View(resDeals);
    }
