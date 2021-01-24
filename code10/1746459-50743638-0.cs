    var query2 = context.CheckinTablets.Select(ct => new
            {
                Id = ct.Id,
                DeviceName = ct.Name,
                StatusName = ct.CheckinTabletStatuses
                    .OrderByDescending(cts => cts.TimestampUtc).FirstOrDefault().Name
            }).ToList();
