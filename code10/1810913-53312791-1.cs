      var duplicate = dt.AsEnumerable()
				.GroupBy(x => new {EventID = x["EventID"].ToString(), ContactID = x["ContactID"].ToString()})
				.Where(x => x.Count() == 1)
				.Select(x =>
				{
					var first = x.First();
					return new
					{
						Type = first["type"],
						Name = first["name"],
						EventID = first["EventID"],
						ContactID = first["ContactID"]
					};
				}).ToDataTable()
