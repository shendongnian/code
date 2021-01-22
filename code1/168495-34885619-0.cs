    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WinForms
    {
        class log
        {
    
    		public static async void Log(int severity, string message)
            {
                await Task.Run(() => LogIt(severity, message));
            }
    
            private static void LogIt(int severity, string message)
            {
                StackTrace st = new StackTrace();
                StackFrame x = st.GetFrame(2);     //the third one goes back to the original caller
                Type t = x.GetMethod().DeclaringType;
                Logger theLogger = LogManager.GetLogger(t.FullName);
    
                //https://github.com/NLog/NLog/wiki/Log-levels
                string[] levels = { "Off", "Trace", "Debug", "Info", "Warn", "Error", "Fatal" };
                int level = Math.Min(levels.Length, severity);
                theLogger.Log(LogLevel.FromOrdinal(level), message);
    
            }
        }
    }
