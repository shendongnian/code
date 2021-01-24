     public ActionResult Test()
        {
            List<Models.Details> detaillist = new List<Models.Details>();
                var data = SessionList;
                var query = data.Select(x => new Models.Details
                {
                    IdString = x.IdString,
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country
                });
                detaillist = query.ToList();
               
                    return View(detaillist);
         
        }
