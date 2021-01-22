	private static object RunMacro(Excel.Application excelApp, string macroName, object[] parameters)
	{
		Type applicationType = excelApp.GetType();
		ArrayList arguments = new ArrayList();
		arguments.Add(macroName);
		if (parameters != null)
			arguments.AddRange(parameters);
		try
		{
			return applicationType.InvokeMember("Run", BindingFlags.Default | BindingFlags.InvokeMethod, null, excelApp, arguments.ToArray());
		}
		catch (TargetInvocationException ex)
		{
			COMException comException = ex.InnerException as COMException;
			
			if (comException != null)
			{
				// These errors are raised by Excel if the macro does not exist
				if (	(comException.ErrorCode == -2146827284)
					||	(comException.ErrorCode == 1004))
					throw new ApplicationException(string.Format("The macro '{0}' does not exist.", macroName), ex);
			}
			
			throw ex;
		}
	}
