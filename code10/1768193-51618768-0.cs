    List<StatisticsModel> models = new List<StatisticsModel>();
    foreach(var i in tasks)
    {
        StaticsModel model = new StatisticsModel();
        var parameters = ToDataTable(tasks.Select(x => new { i.TaskId, i.Name }).ToList());
        var timeOfTasks = db.ExeSQLParamTable("usp_Get_WorkedProyectTime", parameters, "@ProjectTimeWorkedTableType");
        var test = (from DataRow dr in timeOfTasks.Rows select (int)dr["TaskName"]).FirstOrDefault();
        model.TaskId = i.TaskId;
        model.Name = i.Name;
        model.Time = test;
        models.Add(model);
    }
