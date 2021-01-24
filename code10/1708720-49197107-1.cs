	IDictionary<string, List<Pesticide>> results = db.Pesticides
				.Where(c => c.Owner == Owner && c.BrandName == PesticidesBrand)
				.GroupBy(c => c.Owner)
				.ToDictionary(d => d.Key, d => d.ToList());
    return results;
