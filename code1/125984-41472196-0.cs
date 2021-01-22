 	public static string AppendDateInFile(string pathVal)
        {
            var patheWithDate = new StringBuilder(pathVal);
            patheWithDate.AppendFormat("{0}x={1}",
                                   pathVal.IndexOf('?') >= 0 ? '&' : '?',
                                   GetLastWriteTimeForFile(pathVal));
            return patheWithDate.ToString();
        }
