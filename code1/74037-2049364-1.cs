        public static string GetErrorMessage(Exception ex, bool includeStackTrace)
        {
            StringBuilder msg = new StringBuilder();
            BuildErrorMessage(ex, ref msg);
            if (includeStackTrace)
            {
                msg.Append("\n");
                msg.Append(ex.StackTrace);
            }
            return msg.ToString();
        }
        private static void BuildErrorMessage(Exception ex, ref StringBuilder msg)
        {
            if (ex != null)
            {
                msg.Append(ex.Message);
                msg.Append("\n");
                if (ex.InnerException != null)
                {
                    BuildErrorMessage(ex.InnerException, ref msg);
                }
            }
        }
