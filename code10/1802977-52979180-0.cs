	List<GroupProduct> results =
		source
			.GroupBy(x => x.Name)
			.Select(x => new GroupProduct()
			{
				Name = x.Key,
				QuantityTotal = x.Sum(y => y.Quantity),
				TotalPrice = x.Sum(y => y.Price),
				Details =
					x
						.Select(y => new DetailProduct()
						{
							Quantity = y.Quantity,
							Price = y.Price,
						})
						.ToList()
			})
			.ToList();
