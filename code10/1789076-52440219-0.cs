    /// <summary>
    /// View model handler for all ViewModel
    /// </summary>
    static class ViewModelHandler
    {
        #region Properties
        /// <summary>
        /// Config reference ViewModel
        /// </summary>
        private static ConfigRefViewModel ConfigRefViewModel = null;
        #endregion
        #region Getter
        /// <summary>
        /// Get the ConfigRefViewModel property
        /// </summary>
        /// <param name="requestClose">The request for closing view</param>
        /// <returns>The view model of config reference view</returns>
        public static ConfigRefViewModel GetConfigRefViewModel(Action requestClose = null)
        {
            if (ViewModelHandler.ConfigRefViewModel != null) return ViewModelHandler.ConfigRefViewModel;
            ViewModelHandler.SetConfigRefViewModel(new ConfigRefViewModel());
            ViewModelHandler.GetConfigRefViewModel().Initialize(requestClose);
            return ViewModelHandler.ConfigRefViewModel;
        }
        #endregion
        #region Setter
        /// <summary>
        /// Set the ConfigRefViewModel property
        /// </summary>
        /// <param name="configRefViewModel">ConfigRefViewModel to set</param>
        private static void SetConfigRefViewModel(ConfigRefViewModel configRefViewModel) => ViewModelHandler.ConfigRefViewModel = configRefViewModel;
        #endregion
    }
