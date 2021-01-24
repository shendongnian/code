    var ans = from p in db.JDE_Processes
              join uuu in db.JDE_Users on p.FinishedBy equals uuu.UserId into uuuj
              from uuu in uuuj.DefaultIfEmpty()
              join h in db.JDE_Handlings on p.ProcessId equals h.ProcessId into hj
              from h in hj
              group new { p, h } by new { p.ProcessId, p.Description, p.StartedOn, p.StartedBy, p.FinishedOn, p.FinishedBy, p.PlannedFinish, p.PlannedStart } into phg
              select new {
                  phg.Key.ProcessId,
                  phg.Key.Description,
                  phg.Key.StartedOn,
                  phg.Key.StartedBy,
                  phg.Key.FinishedOn,
                  phg.Key.FinishedBy,
                  phg.Key.PlannedFinish,
                  phg.Key.PlannedStart,
                  HandlingStatus = phg.Where(ph => ph.h.IsCompleted == null).Count()
              };
