    public static void Test()
	{
		var DocList = AskUserToSelectDocs();
		//save working db reference
		Database originalDB = HostApplicationServices.WorkingDatabase;
		foreach (string FileName in DocList.Files)
		{
			//a little trick here:
			//construct the database in memory, and read in the target file.
			//now your database is your working database, not the active doc!!
			using (Database database = new Database(false, true))
			{
				database.ReadDwgFile(FileName, System.IO.FileShare.ReadWrite, true, string.Empty);
				HostApplicationServices.WorkingDatabase = database;//important!
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					//do your stuff
				}
                //reset WorkingDB to original db
				HostApplicationServices.WorkingDatabase = originalDB;
				database.SaveAs(FileName, DwgVersion.Current);
			}
		}
	}
