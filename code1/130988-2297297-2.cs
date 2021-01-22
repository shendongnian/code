    public class CreateUserTaskInfo
	{
		public string username { get; };
		public string password { get; };
		public string sqlServer { get; };
		public string database { get; };
		public string practice { get; };
		public RemoteUserManager client { get; };
		public CreateUserTaskInfo(RemoteUserManager cli, string usr, string pass, string sql, string db, string prac)
		{
			client = cli;
			username = usr;
			password = pass;
			sqlServer = sql;
			database = db;
			practice = prac;
		}
    }
    public void ExampleFunction(...)
    {
        //gather up the variables to be passed in
        var taskInfo = new CreateUserTaskInfo(remote, user, password, SqlInstancePath, AccountID, practiceName);
        //queue the background work and pass in the state object.
        ThreadPool.QueueUserWorkItem(new WaitCallback(RemoteUserManagerClient.CreateUser), taskInfo);
    }
    static public void CreateUser(object stateInfo)
	{
		CreateUserTaskInfo ti = (CreateUserTaskInfo)stateInfo;
		
        //use ti in the method and access the properties, it will be 
        // the same object as taskInfo from the other method
	}
