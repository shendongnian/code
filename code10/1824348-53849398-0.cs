    public static SampleViewModel currentInstance;
        /// <summary>
        /// Currents the instance this view mode shared on two place.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <param name="navigation">Navigation.</param>
        public static SampleViewModel CurrentInstance(INavigation navigation)
        {
            if (currentInstance == null)
                return currentInstance = new SampleViewModel(navigation);
            else
                return currentInstance;
        }
