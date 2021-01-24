    public ActionResult draw_chart(string city)
                    {
                        var query = from citiez in db.cities
                                    join site in db.sites on citiez.city_id equals site.city_id
                                    join ords in db.orders on site.site_id equals ords.site_id
                                    where  citiez.city_name == city                            
                                    group site by site.site_id into grouped
                                    select new
                                    {
                                       
                                        siteId = grouped.Key,
                                        ordersforsite = grouped.Count(),
                                    };
                        var list = query.ToList();
                        return Json(list, JsonRequestBehavior.AllowGet);
                    }
    
     
