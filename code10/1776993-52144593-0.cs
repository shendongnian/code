        /// <summary>
        /// Logs an exception as an error in the provided logger,
        /// formatting message and stacktrace.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="e"></param>
        public static void ErrorFromException(this ILog logger, Exception e)
        {
            ErrorFromException(logger, null, e);
        }
        /// <summary>
        /// Logs an exception as an error in the provided logger,
        /// formatting message and stacktrace.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="prefix"></param>
        /// <param name="e"></param>
        public static void ErrorFromException(this ILog logger, string prefix, Exception e)
        {
            if (logger == null) return;
            if (e == null)
            {
                logger.Error(
                    "LogExtension.ErrorFromException: A null exception was formatted. Probably there is a bug in the logging call.");
                return;
            }
            var sb = new StringBuilder(400);
            if (!String.IsNullOrEmpty(prefix))
                sb.AppendLine(prefix);
            sb.AppendLine("Caught exception (" + e.GetType().Name + "): " + e.Message);
            sb.AppendLine(e.StackTrace);
            var innerEx = e;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
                sb.AppendLine("Inner exception (" + innerEx.GetType().Name + "): " + innerEx.Message);
                sb.AppendLine(innerEx.StackTrace);
            }
            sb.AppendLine();
            logger.Error(sb.ToString());
        }
