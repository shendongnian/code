    protected virtual string GetConnectionString()
    {
	string connectionString;
	string connectionStringSource;
	//In app.config?
	if (ConfigurationManager.AppSettings[_ConnectionStringName] != null &&
	   ConfigurationManager.AppSettings[_ConnectionStringName] != "")
	{
	   connectionString = ConfigurationManager.AppSettings[_ConnectionStringName];
	   connectionStringSource = "Config settings";
	}
	//Nope? Check Session
	else if (null != HttpContext.Current && null != HttpContext.Current.Session &&
	   null != HttpContext.Current.Session[_ConnectionStringName])
	{
	  connectionString = (string)HttpContext.Current.Session[_ConnectionStringName];
	  connectionStringSource = "Session";
	}
	//Nope? Check Thread
	else if (null != System.Threading.Thread.GetData(
          System.Threading.Thread.GetNamedDataSlot(_ConnectionStringName)))
	{
	   connectionString = (string)System.Threading.Thread.GetData(
              System.Threading.Thread.GetNamedDataSlot(_ConnectionStringName));
	   connectionStringSource = "ThreadLocal";
	}
	else
	{
	   throw new ApplicationException("Can't find a connection string");
	}
	if (debugLogging)
   	   log.DebugFormat("Connection String '{0}' found in {1}", connectionString, 
              connectionStringSource);
	return connectionString;
	}
