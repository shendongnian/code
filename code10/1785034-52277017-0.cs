    List<string> patientIds = new List<string>();
    var schedules = scheduleEntities.schedules.Where(s => s.StartTime > somedate && s.EndDate < DateTime.Now).ToList();
    var tasks = taskEntities.Tasks.ToList();
            
    var items =
        from schedule in schedules
        join task in tasks on schedule.Id equals task.ScheduleId
        orderby schedule.StartTime descending
        select new { task.PersonId, schedule.StartTime, task.State };
    var itemgroups = items.GroupBy(i => i.PersonId).ToList();
    foreach (var item in itemgroups)
    {
        if ((item.Count() >= 2 && (item.ElementAt(0).State == "StateX" && item.ElementAt(1).State == "StateX"))
            ||
            (item.Count() >= 3 && (item.ElementAt(0).State == "StateX" && item.ElementAt(1).State == "StateEmpty" && item.ElementAt(2).State == "StateX")))
        {
            patientIds.Add(item.Key);
        }
    }
