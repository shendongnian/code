    var items = (from p in db.JDE_Processes
                                 join uuu in db.JDE_Users on p.FinishedBy equals uuu.UserId into finished
                                 from fin in finished.DefaultIfEmpty()
                                 join uu in db.JDE_Users on p.StartedBy equals uu.UserId into started
                                 from star in started.DefaultIfEmpty()
                                 join h in db.JDE_Handlings on p.ProcessId equals h.ProcessId into hans
                                 from ha in hans.DefaultIfEmpty()
                                 where p.TenantId == tenants.FirstOrDefault().TenantId && p.CreatedOn >= dFrom && p.CreatedOn <= dTo
                                 group new { p, fin, star, ha }
                                 by new {
                                     p.ProcessId,
                                     p.Description,
                                     p.StartedOn,
                                     p.StartedBy,
                                     p.FinishedOn,
                                     p.FinishedBy,
                                     p.PlannedFinish,
                                     p.PlannedStart,
                                     fin.Name,
                                     fin.Surname,
                                     StarterName = star.Name, // <-- Creating alias
                                     StarterSurname = star.Surname // <-- Creating alias
                                 } into grp
                                 orderby grp.Key.ProcessId descending
                                 select new Process
                                 {
                                     ProcessId = grp.Key.ProcessId,
                                     Description = grp.Key.Description,
                                     StartedOn = grp.Key.StartedOn,
                                     StartedBy = grp.Key.StartedBy,
                                     StartedByName = grp.Key.StarterName + " " + grp.Key.StarterSurname,
                                     FinishedOn = grp.Key.FinishedOn,
                                     FinishedBy = grp.Key.FinishedBy,
                                     FinishedByName = grp.Key.Name + " " + grp.Key.Surname,
                                     PlannedStart = grp.Key.PlannedStart,
                                     PlannedFinish = grp.Key.PlannedFinish,
                                     HandlingStatus = grp.Where(ph=>ph.ha.IsCompleted == null && ph.ha.HandlingId >0).Count().ToString()
                                 });
