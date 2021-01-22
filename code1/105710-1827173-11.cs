    public class MyCustomLoggerAdapter : ILoggerFacade
    {
        
        #region ILoggerFacade Members
    
        /// <summary>
        /// Logs an entry using the Enterprise Library logging. 
        /// For logging a Category.Exception type, it is preferred to use
        /// the EnterpriseLibraryLoggerAdapter.Exception methods."
        /// </summary>
        public void Log( string message, Category category, Priority priority )
        {
            if( category == Category.Exception )
            {
                Exception( new Exception( message ), ExceptionPolicies.Default );
                return;
            }
    
            Logger.Write( message, category.ToString(), ( int )priority );
        }
    
        #endregion
    
    
        /// <summary>
        /// Logs an entry using the Enterprise Library Logging.
        /// </summary>
        /// <param name="entry">the LogEntry object used to log the 
        /// entry with Enterprise Library.</param>
        public void Log( LogEntry entry )
        {
            Logger.Write( entry );
        }
    
        // Other methods if needed, i.e., a default Exception logger.
        public void Exception ( Exception ex ) { // do stuff }
    }
