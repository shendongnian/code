		var ss =
			db
				.SubToSubMenus
				.Join(
					db.MenuPermissions,
					s => s.ID,
					p => p.SubToSubMenuId,
					(s, p) => new { s, p })
				.Where(w => w.s.Active == true && w.p.RoleId == roleId && w.p.hasPermission == true)
				.Select(s => new
				{
					ID = s.s.ID,
					SubToSubMenuName = s.s.SubToSubMenuName,
					Description = s.s.Description,
				})
				.ToList()
				.Select(s => new SubToSubMenu()
				{
					ID = s.ID,
					SubToSubMenuName = s.SubToSubMenuName,
					Description = s.Description,
				})
				.ToList();
