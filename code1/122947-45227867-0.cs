    class Settings : INotifyPropertyChanged
    {
        private static Settings _currentSettings = new Settings();
    
        /// <summary> The one and only Current Settings that is the current Project. </summary>
        [JsonIgnore] // so it isn't serialized by JSON.NET
        public static Settings CurrentSettings //  http://csharpindepth.com/Articles/General/Singleton.aspx 
        {
            get { return _currentSettings; }
    
            // setter is to load new settings into the current settings (using JSON.NET). Hey, it works. Probably not thread-safe.
            internal set 
            {
                Log.Verbose("CurrentSettings was reset. Project Name: {projectName}", value.ProjectName);
                _currentSettings = value;
                _currentSettings.IsChanged = false;
                NotifyStaticPropertyChanged("CurrentSettings");
            }
        }
    
        // http://10rem.net/blog/2011/11/29/wpf-45-binding-and-change-notification-for-static-properties
        /// <summary> Fires when the Curent CurrentTvCadSettings is loaded with new settings
        ///           Event queue for all listeners interested in StaticPropertyChanged events. </summary>
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged = delegate { };
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        
        // various instance properties including ....
        
        public string ProjectName {get; set;}
        
        [JsonIgnore]
        public bool IsChanged { get; set; } 
    }
