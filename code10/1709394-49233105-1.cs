    protected async Task<bool> SaveChangesWithLogs()
        {
          List logs = await DbContext.SaveChangesWithLogs();
          foreach (string log in logs)
          {
            LogInfo(log); //just prints the generated logs
          }      
    	  return true;
        }
    public static async Task<List<myLogType>> SaveChangesWithLogs(this DbContext dbContext)
    {
        List<myLogType> logs = null;
        //pre-save prepare logs
        await dbContext.SaveChanges();
        //post-save modifications of logs
        return logs;
    }
