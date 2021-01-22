    var qry = from timeEntry in timeEntries
                      let date = timeEntry.StartTime.Date
                      where timeEntry.TimesheetId == timesheetId
                      && date >= start
                      && date <= end
                      group timeEntry by timeEntry.Task.TaskName into grp
                      select new
                      {
                          TaskName = grp.Key,
                          Monday = grp.Where(x => x.StartTime.DayOfWeek == DayOfWeek.Monday).Select(x=>x.EndTime.Subtract(x.StartTime).Minutes).Sum(),
                          Tuesday = grp.Where(x => x.StartTime.DayOfWeek == DayOfWeek.Tuesday).Select(x => x.EndTime.Subtract(x.StartTime).Minutes).Sum(),
                          Wednesday = grp.Where(x => x.StartTime.DayOfWeek == DayOfWeek.Wednesday).Select(x => x.EndTime.Subtract(x.StartTime).Minutes).Sum(),
                          Thursday = grp.Where(x => x.StartTime.DayOfWeek == DayOfWeek.Thursday).Select(x => x.EndTime.Subtract(x.StartTime).Minutes).Sum(),
                          Friday = grp.Where(x => x.StartTime.DayOfWeek == DayOfWeek.Friday).Select(x => x.EndTime.Subtract(x.StartTime).Minutes).Sum(),
                      };
