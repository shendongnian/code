    private string GetAllRoleDefinitionHierarchies()
    {
        AzAuthorizationStore azManStore = new AzAuthorizationStoreClass();
        azManStore.Initialize(0, "connectionstring", null);
        IAzApplication3 azApp = azManStore.OpenApplication("TestApp", null) as IAzApplication3;
        
        if (azApp == null)
            throw new NotSupportedException("Getting Role Definitions is not supported by older versions of AzMan COM interface");
        StringBuilder output = new StringBuilder();
        foreach (IAzRoleDefinition currentRoleDefinition in azApp.RoleDefinitions)
        {
            output.Append(currentRoleDefinition.Name + "<br />");
            Array roleTasks = (Array) currentRoleDefinition.Tasks;
            foreach (string taskId in roleTasks)
            {
                IAzTask currentTask = azApp.OpenTask(taskId, null);
                output.Append("&nbsp;&nbsp; - Task: " + currentTask.Name + "<br />");
                Array taskOperations = (Array)currentTask.Operations;
                foreach (string operationId in taskOperations)
                {
                    IAzOperation currentOperation = azApp.OpenOperation(operationId, null);
                    output.Append("&nbsp;&nbsp;&nbsp;&nbsp; - Operation: " + currentOperation.Name + "<br />");
                }
            }
        }
        return output.ToString();
    }
