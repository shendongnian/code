    public class MyCustomLoggerAdapterExtendedAdapter : MyCustomLoggerAdapter, IFormalLogger
    {
    
        private readonly ILoggingPolicySection _config;
        private LogEntry _infoPolicy;
        private LogEntry _debugPolicy;
        private LogEntry _warnPolicy;
        private LogEntry _errorPolicy;
    
        private LogEntry InfoLog
        {
            get
            {
                if( _infoPolicy == null )
                {
                    LogEntry log = GetLogEntryByPolicyName( LogPolicies.Info );
                    _infoPolicy = log;
                }
                return _infoPolicy;
            }
        }
    
        // removed backing code for brevity
        private LogEntry DebugLog... WarnLog... ErrorLog
    
    
        // ILoggingPolicySection is passed via constructor injection in the bootstrapper
        // and is used to configure various logging policies.
        public MyCustomLoggerAdapterExtendedAdapter ( ILoggingPolicySection loggingPolicySection )
        {
            _config = loggingPolicySection;
        }
    
    
        #region IFormalLogger Members
    
        /// <summary>
        /// Info: informational statements concerning program state, 
        /// representing program events or behavior tracking.
        /// </summary>
        /// <param name="message"></param>
        public void Info( string message )
        {
            InfoLog.Message = message;
            InfoLog.ExtendedProperties.Clear();
            base.Log( InfoLog );
        }
    
        /// <summary>
        /// Debug: fine-grained statements concerning program state, 
        /// typically used for debugging.
        /// </summary>
        /// <param name="message"></param>
        public void Debug( string message )
        {
            DebugLog.Message = message;
            DebugLog.ExtendedProperties.Clear();
            base.Log( DebugLog );
        }
    
        /// <summary>
        /// Warn: statements that describe potentially harmful 
        /// events or states in the program.
        /// </summary>
        /// <param name="message"></param>
        public void Warn( string message )
        {
            WarnLog.Message = message;
            WarnLog.ExtendedProperties.Clear();
            base.Log( WarnLog );
        }
    
        /// <summary>
        /// Error: statements that describe non-fatal errors in the application; 
        /// sometimes used for handled exceptions. For more defined Exception
        /// logging, use the Exception method in this class.
        /// </summary>
        /// <param name="message"></param>
        public void Error( string message )
        {
            ErrorLog.Message = message;
            ErrorLog.ExtendedProperties.Clear();
            base.Log( ErrorLog );
        }
    
        /// <summary>
        /// Logs an Exception using the Default EntLib Exception policy
        /// as defined in the Exceptions.config file.
        /// </summary>
        /// <param name="ex"></param>
        public void Exception( Exception ex )
        {
            base.Exception( ex, ExceptionPolicies.Default );
        }
    
        #endregion
    
    
        /// <summary>
        /// Creates a LogEntry object based on the policy name as 
        /// defined in the logging config file.
        /// </summary>
        /// <param name="policyName">name of the policy to get.</param>
        /// <returns>a new LogEntry object.</returns>
        private LogEntry GetLogEntryByPolicyName( string policyName )
        {
            if( !_config.Policies.Contains( policyName ) )
            {
                throw new ArgumentException( string.Format(
                  "The policy '{0}' does not exist in the LoggingPoliciesCollection", 
                  policyName ) );
            }
    
            ILoggingPolicyElement policy = _config.Policies[policyName];
    
            var log = new LogEntry();
            log.Categories.Add( policy.Category );
            log.Title = policy.Title;
            log.EventId = policy.EventId;
            log.Severity = policy.Severity;
            log.Priority = ( int )policy.Priority;
            log.ExtendedProperties.Clear();
    
            return log;
        }
    
    }
    public interface IFormalLogger
    {
    
        void Info( string message );
    
        void Debug( string message );
    
        void Warn( string message );
    
        void Error( string message );
    
        void Exception( Exception ex );
    
    }
