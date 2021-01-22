    using System.Diagnostics;
	class TestClass
	{
		private EventLog log;
			
		public TestClass()
		{
			if(!EventLog.SourceExists("TestApplication"))
			{
				EventLog.CreateEventSource("TestApplication","Application");
			}
			log=new EventLog("Application",".","TestApplication");
		}
		
		public int ParseFile(StreamReader sr)
		{
			string[] lines=sr.ReadToEnd().Trim().Split('\n');
			int linecount=lines.Length;
			string connString=System.Configuration.ConfigurationSettings.AppSettings["ConnectString"];
			SqlConnection conn=new SqlConnection(connString);
			try
			{
				conn.Open();
			}
			catch (Exception e)
			{
				log.WriteEntry("Cannot connect to database for file import: "+e.Message, EventLogEntryType.Error,1171);
				return linecount;
			}
			// write to database, etc.
		}
	}
	
