    var models = tasks.Select(i => {
        var parameters = ToDataTable(tasks.Select(x => new { i.TaskId, i.Name }).ToList());
        var timeOfTasks = db.ExeSQLParamTable("usp_Get_WorkedProyectTime", parameters, "@ProjectTimeWorkedTableType");
        var test = (from DataRow dr in timeOfTasks.Rows select (int)dr["TaskName"]).FirstOrDefault();
        return new StatisticsModel {
            TaskId = i.TaskId
        ,   Name = i.Name
        ,   Time = test
        };
    }).ToList();
