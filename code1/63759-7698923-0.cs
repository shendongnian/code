    // Add COM-Reference to "TaskScheduler 1.1 Type Library" to the project
    using TaskScheduler;
    // code in function X
    TaskSchedulerClass TaskClass = new TaskSchedulerClass();
    TaskClass.Connect();
    // access one task (or search for it or enumerate over all tasks)
    IRegisteredTask lTask = null;
    lTask = TaskClass.GetFolder("\\").GetTasks(0)[0];
    // provide domain\\username and password (ask user for it, use encryption)
    string lUsername = "TestDomain\\TestUsername"; // TestDomain can be the hostname for a local user
    string lPassword = "xyzPassword";
    RegisterTaskDefinition(lTask.Path, lTask.Definition, (int)_TASK_CREATION.TASK_UPDATE, lUsername, lPassword, lTask.Definition.Principal.LogonType, Type.Missing);
   
