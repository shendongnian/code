    public class DateTimeProvider : IDisposable 
    { 
        [ThreadStatic] 
        private static DateTime? _injectedDateTime; 
 
        private DateTimeProvider() 
        { 
        } 
 
        /// <summary> 
        /// Gets DateTime now. 
        /// </summary> 
        /// <value> 
        /// The DateTime now. 
        /// </value> 
        public static DateTime Now 
        { 
            get 
            { 
                return _injectedDateTime ?? DateTime.Now; 
            } 
        } 
 
        /// <summary> 
        /// Injects the actual date time. 
        /// </summary> 
        /// <param name="actualDateTime">The actual date time.</param> 
        public static IDisposable InjectActualDateTime(DateTime actualDateTime) 
        { 
            _injectedDateTime = actualDateTime; 
 
            return new DateTimeProvider(); 
        } 
 
        public void Dispose() 
        { 
            _injectedDateTime = null; 
        } 
    } 
