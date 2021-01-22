        static string GetCurrentStackTrace(DTE dte)
        {
            bool canGetStackTrace =
                (dte != null) &&
                (dte.Debugger != null) &&
                (dte.Debugger.CurrentThread != null) &&
                (dte.Debugger.CurrentThread.StackFrames != null);
            if (!canGetStackTrace)
                return string.Empty;
            StringBuilder stackTrace = new StringBuilder();
            foreach (StackFrame frame in dte.Debugger.CurrentThread.StackFrames)
            {
                stackTrace.AppendFormat("{0}\n", frame.FunctionName);
            }
            return stackTrace.ToString();
        }
