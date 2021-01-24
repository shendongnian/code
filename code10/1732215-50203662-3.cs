    var viewModel = (from rd in _db.ResData
                                      join ra in _db.ResAvailability on rd.RecNo equals ra.RecNoDate
                                      where ra.TotalPrice < Int32.Parse(resDeals.priceHighEnd) && ra.TotalPrice > Int32.Parse(resDeals.priceLowEnd)
                                      .Take(10)
                                      select new ClassNameViewModel
                                      {
                                          Name = rd.Name,
                                          ImageUrl = rd.ImageUrl,
                                          ResortDetailViewModels = rd.ResortDetails.Select(o => 
                                                                              new ResortDetailViewModel
                                                                              {
                                                                                   Detail1 = o.detail1,
                                                                                   Detail2 = o.detail2,
                                                                                   ... etc. ...
                                                                              },
                                          CheckIn = ra.CheckIn,
                                          Address = rd.Address,
                                          TotalPrice = ra.TotalPrice
                                      });
    return View(viewModel);
