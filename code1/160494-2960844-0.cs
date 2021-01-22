        static string GetCurrentStackTrace(DTE dte)
        {
            bool canGetStackTrace =
                (dte != null) &&
                (dte.Debugger != null) &&
                (dte.Debugger.CurrentThread != null) &&
                (dte.Debugger.CurrentThread.StackFrames != null);
            if (!canGetStackTrace)
                return string.Empty;
            return string.Join(
                "\n",
                dte.Debugger.CurrentThread.StackFrames.Cast<StackFrame>().Select(f => f.FunctionName)
            );
        }
