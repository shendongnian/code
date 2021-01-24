            var result = await (from g in DbContext.WorkTeamUsers
                       group g.WorkUser by g.WorkTeam.Name into grp
                       select new
                       {
                           TeamName = grp.Key,
                           Users = grp.ToList()
                       }).ToListAsync();
