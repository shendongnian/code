    public enum ApplicationSingleInstanceMode
    {
        CurrentUserSession,
        AllSessionsOfCurrentUser,
        Pc
    }
    
    public class ApplicationSingleInstancePerUser: IDisposable
    {
        private readonly EventWaitHandle _event;
    
        /// <summary>
        /// Shows if the current instance of ghost is the first
        /// </summary>
        public bool FirstInstance { get; private set; }
    
        /// <summary>
        /// Initializes 
        /// </summary>
        /// <param name="applicationName">The application name</param>
        /// <param name="mode">The single mode</param>
        public ApplicationSingleInstancePerUser(string applicationName, ApplicationSingleInstanceMode mode = ApplicationSingleInstanceMode.CurrentUserSession)
        {
            string name;
            if (mode == ApplicationSingleInstanceMode.CurrentUserSession)
                name = $"Local\\{applicationName}";
            else if (mode == ApplicationSingleInstanceMode.AllSessionsOfCurrentUser)
                name = $"Global\\{applicationName}{Environment.UserDomainName}";
            else
                name = $"Global\\{applicationName}";
    
            try
            {
                bool created;
                _event = new EventWaitHandle(false, EventResetMode.ManualReset, name, out created);
                FirstInstance = created;
            }
            catch
            {
            }
        }
    
        public void Dispose()
        {
            _event.Dispose();
        }
    }
