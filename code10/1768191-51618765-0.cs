    List<StatisticsModel> allModels = new List<StatisticsModel>();
    foreach(var i in tasks)
    {
        StatisticsModel model = new StatisticsModel();
        var parameters = ToDataTable(tasks.Select(x => new { i.TaskId, i.Name }).ToList());
        var timeOfTasks = db.ExeSQLParamTable("usp_Get_WorkedProyectTime", parameters, "@ProjectTimeWorkedTableType");
        var test = (from DataRow dr in timeOfTasks.Rows select (int)dr["TaskName"]).FirstOrDefault();
        model.TaskId = i.TaskId;
        model.Name = i.Name;
        model.Time = test
        allModels.Add(model);
     }
     var final2 = allModels;
