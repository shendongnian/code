	private static string GetData(int taskID, int typeID)
	{
		try
		{
			using (TaskCardContext.TaskMaintenanceDataDataContext dc = new TaskCardContext.TaskMaintenanceDataDataContext())
			{
                //This was taken from Jons answer!!
                var query = c.TaskRelations.Where(r => r.TaskId == taskID 
                                                  && r.RelTypeId == typeID))
                                           .Select(r => r.RefAliSpReq.shortdesc);
                return string.Join("; ", query.ToArray());
			}
		}
		catch
		{
			return String.Empty;
		}
	}
