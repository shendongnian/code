	var groups = items.GroupBy(i => (i.Id, i.Name))
	     .Select(grp => new 
		 {
		 	grp.Key.Id, 
			grp.Key.Name, 
			TagIds = grp.Where(i => i.TagId != null)
			            .Select(x => x.TagId)
						.ToArray(),
			DepartmentId = grp.FirstOrDefault(i => i.DepartmentId != null)?.DepartmentId,
			Codes = grp.Where(i => i.Code != null)
			            .Select(x => x.Code)
						.ToArray(),
        });
