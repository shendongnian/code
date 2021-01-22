            var projectData = (from p in db.Projects
                          orderby p.title
                          select new
                          {
                              Title = p.title,
                              DevURL = p.devURL ?? "N/A",
                              QAURL = p.qaURL ?? "N/A",
                              LiveURL = p.liveURL ?? "N/A",
                              Users = p.GetUsers().MakeUserList()
                          }).ToList();
