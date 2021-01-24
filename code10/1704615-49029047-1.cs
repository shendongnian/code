            /// <summary>
        /// The log. 
        /// Getting Logger instance from key name defined in Web.config of main web file. Key name is LoggerInstanceName
        /// On the basis of name , logger instance and defined rules can be switched from one to another.
        /// </summary>
        private static readonly NLog.Logger Log = LogManager.GetLogger(Convert.ToString(ConfigurationManager.AppSettings.Get("LoggerInstance")));
