    ThreadPool.QueueUserWorkItem(new WaitCallback(RemoteUserManagerClient.CreateUser),
        new CreateUserTaskInfo(Program.Context, remote, user, password, SqlInstancePath, AccountID, practiceName));
    public class CreateUserTaskInfo
	{
		public PrincipalContext context;
		public string username;
		public string password;
		public string sqlServer;
		public string database;
		public string practice;
		public RemoteUserManager client;
		public CreateUserTaskInfo(PrincipalContext con, RemoteUserManager cli, string usr, string pass, string sql, string db, string prac)
		{
			client = cli;
			context = con;
			username = usr;
			password = pass;
			sqlServer = sql;
			database = db;
			practice = prac;
		}
    }
