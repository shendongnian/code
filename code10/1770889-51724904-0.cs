    var result = dtTimephasedStatusTemp.AsEnumerable().
        GroupBy(x => new { TaskId = x.Field<string>("Task Id") }).
        Select(x => new
        {
            TaskId = x.Key.TaskId,
            TaskActualWorkSum = x.Sum(y => Double.Parse(y.Field<string>("TaskActualWork"))),
            TaskWorkSum = x.Sum(y => Double.Parse(y.Field<string>("TaskWork")))
        }); 
