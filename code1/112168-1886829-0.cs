    public static class ExceptionFormatterExtensions
    {
        public static string ExceptionToString (
            this Exception ex, 
            Action<StringBuilder> customFieldsFormatterAction)
        {
            StringBuilder description = new StringBuilder();
            description.AppendFormat("{0}: {1}", ex.GetType().Name, ex.Message);
            if (customFieldsFormatterAction != null)
                customFieldsFormatterAction(description);
            if (ex.InnerException != null)
            {
                description.AppendFormat(" ---> {0}", ex.InnerException);
                description.AppendFormat(
                    "{0}   --- End of inner exception stack trace ---{0}",
                    Environment.NewLine);
            }
            description.Append(ex.StackTrace);
            return description.ToString();
        }
    }
