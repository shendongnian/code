	PesticideModel record = db.Pesticides
				.Where(c => c.Owner == Owner && c.BrandName == PesticidesBrand)
				.Select(c => new PesticideModel{ Owner = c.Owner, BrandName = c.BrandName, ID = c.ID, Type = c.Type })
				.FirstOrDefault();
				
