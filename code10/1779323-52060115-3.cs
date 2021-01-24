    var query = (from r in countries
            where country == null || country.Any(c => c.Trim().ToLower().Contains(r.Name.Trim().ToLower()))
            select new
            {
               CountryName = r.Name,
               CountryCode = r.Code
            });
    var result = query.ToList();
