        public MainViewModel(IScreen hostScreen = null)
        {
            this.HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }
        /// <inheritdoc />
        public string UrlPathSegment => "Main";
        /// <inheritdoc />
        public IScreen HostScreen { get; }
