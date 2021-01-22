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
    static public void CreateUser(object stateInfo)
	{
		CreateUserTaskInfo ti = (CreateUserTaskInfo)stateInfo;
		lock (userLock)
		{
			if (UserPrincipal.FindByIdentity(ti.context, ti.username) == null)
			{
				using (UserPrincipal u = new UserPrincipal(ti.context, ti.username, ti.password, true))
				{
					u.PasswordNeverExpires = true;
					u.UserCannotChangePassword = true;
					u.Save();
					using (GroupPrincipal g = GroupPrincipal.FindByIdentity(ti.context, "Remote Desktop Users"))
					{
						g.Members.Add(u);
						g.Save();
					}
				}
			}
		}
		lock (editLock)
		{
			ti.client.Edit(ti.username, null, ti.sqlServer, ti.database, ti.practice);
		}
	}
