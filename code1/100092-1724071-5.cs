        private static void ProcessAzManRoleDefinitions(IAzApplication app, IAzTask task, int level, Action<string, string, int> callbackAction)
        {
            bool isRole = (task.IsRoleDefinition == 1);
 
            callbackAction((isRole ? "Role" : "Task"), task.Name, level);
            level++;
            // Iterate over any subtasks defined for this task (or role)
            Array tasks = (Array)task.Tasks;
            foreach (string taskName in tasks)
            {
                IAzTask currentTask = app.OpenTask(taskName, null);
                // Need to recursively process child roles and tasks
                ProcessAzManRoleDefinitions(app, currentTask, level, callbackAction);
            }
        
            // Iterate over any opeations defined for this task (or role)
            Array taskOperations = (Array)task.Operations;
            foreach (string operationName in taskOperations)
                callbackAction("Operation", operationName, level);
        }
        private static string GetRoleDefinitionHierarchy()
        {
            AzAuthorizationStore azManStore = new AzAuthorizationStoreClass();
            azManStore.Initialize(0, "connectionstring", null);
            IAzApplication azApp = azManStore.OpenApplication("TestApp", null);
            
            StringBuilder output = new StringBuilder();
            
            foreach (IAzTask task in azApp.Tasks)
            {
                if (task.IsRoleDefinition == 1)
                    ProcessAzManRoleDefinitions(azApp, task, 0, (type, name, level) => output.Append("".PadLeft(level * 2) + type + ": " + name + "\n"));
            }
            return output.ToString();
        }
