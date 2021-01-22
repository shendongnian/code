    MSProject.Tasks tasks = Globals.ThisAddIn.ProjectApp.ActiveProject.Tasks;
    for (int TaskNo = 1; TaskNo <= tasks.Count; TaskNo++)
    {
       string TaskName;
       TaskName = tasks[TaskNo].Name;
     // more code
    }
