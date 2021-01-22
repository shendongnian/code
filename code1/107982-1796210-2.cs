    var rooms = roomBinding.GroupBy(g => new { Id = g.R_ID, Name = g.r_name })
					       .Select(g => new
							   {
								   Id = g.Key.Id,
								   Name = g.Key.Name,
								   Count = g.Count()
							   });
