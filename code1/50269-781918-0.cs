    try 
    {
    	string assembly  = ConfigurationSettings.AppSettings["DataProvider"].Split(',')[0];
    	string classname = ConfigurationSettings.AppSettings["DataProvider"].Split(',')[1];
    	m_Instance = (SqlDataProvider)Activator.CreateInstance(assembly,classname).Unwrap();
    }
    catch(Exception ex) 
    {
    	Common.Error.Write("Getting Data Provider From Config");
    }
