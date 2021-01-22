	void Main()
	{
		var dc=this;
		var sql="SELECT TOP 1 "
                  + "HAS_PERMS_BY_NAME(db_name(), 'DATABASE', 'ANY') DoIHaveAnyRights;";
		var result=dc.ExecuteStoreQuery<Rights>(sql);
		if (result1.DoIHaveAnyRights==1)
		{
			Console.WriteLine("OK"); // ok
		}
		else
		{
			// no rights: Show error etc.
			Console.WriteLine("No rights"); // ok
		}
	}
	
	public class Rights
	{
		public Int32 DoIHaveAnyRights { get; set; }
	}
