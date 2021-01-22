    public static class ParameterChecker
    {
        public static void CheckForNull(Hashtable parameters)
        {
            foreach (DictionaryEntry param in parameters)
            {
                if (param.Value == null || string.IsNullOrEmpty(param.Value as string))
                {
                    throw new ArgumentNullException(param.Key.ToString());
                }
            }
        }
    }
