    Dim logging = GetType(Net.HttpWebRequest).Assembly.GetType("System.Net.Logging")
    Dim enabled = logging.GetField("s_LoggingEnabled", Reflection.BindingFlags.NonPublic Or  Reflection.BindingFlags.Static)
    enabled.SetValue(Nothing, True)
    Dim webTr = logging.GetProperty("Web", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static)
    Dim tr as TraceSource = webTr.GetValue(Nothing, Nothing)
    tr.Switch.Level = SourceLevels.Verbose
    tr.Listeners.Add(New MyTraceListener())
