        public void LogError(string message, params object[] parameters)
        {
            if (parameters.Length > 0)
                LogError(string.Format(message, parameters));
            else
                LogError(message);
        }
