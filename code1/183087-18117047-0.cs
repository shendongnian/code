	public static EmailTraceListenerData GetEmailLogConfiguration()
	{
		var rootWebConfig1 = WebConfigurationManager.OpenWebConfiguration("/");
		var section = rootWebConfig1.GetSection("loggingConfiguration");
		var loggingSection = section as Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings;
		if (loggingSection != null) {
            // Reference to Microsoft.Practices.EnterpriseLibrary.Logging.dll and
            // Microsoft.Practices.EnterpriseLibrary.Common.dll required for the code below
			foreach (Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.TraceListenerData listener in loggingSection.TraceListeners) {
				var emailTraceListenerData = listener as EmailTraceListenerData;
				if (emailTraceListenerData != null) {
                    // Can obtain FromAddress, ToAddress, SmtpServer and SmtpPort 
                    // as property of  emailTraceListenerData;
                    return emailTraceListenerData;
				}
			}
		}
		return null;
	}
