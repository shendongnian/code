	PesticideModel record = db.Pesticides
				.Where(c => c.Owner == Owner && c.BrandName == PesticidesBrand)
				.Select(c => new PesticideModel{ c.Owner, c.BrandName, c.ID, c.Type })
				.FirstOrDefault();
				
