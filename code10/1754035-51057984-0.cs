    var result = from r in dataset 
    	group r by new { r.Id, r.Name } into grouping
    	select new Owner { 
    		Id = grouping.Key.Id, 
    		Name = grouping.Key.Name,
    		Cars = grouping.Select(g => new Car { Brand = g.CarBrand, Model = g.CarModel }).ToList()
    	};
