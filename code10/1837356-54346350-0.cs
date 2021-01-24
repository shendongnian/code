    C# Timer trigger function exception: System.TypeLoadException: Could not load type 'System.Security.Principal.WindowsImpersonationContext' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
       at Microsoft.AnalysisServices.IdentityResolver.Dispose()
       at Microsoft.AnalysisServices.XmlaClient.Connect(ConnectionInfo connectionInfo, Boolean beginSession)
       at Microsoft.AnalysisServices.Core.Server.Connect(String connectionString, String sessionId, ObjectExpansion expansionType)
       at Submission#0.Run(TimerInfo myTimer, TraceWriter log) in D:\home\site\wwwroot\TimerTrigger1\run.csx:line 16
