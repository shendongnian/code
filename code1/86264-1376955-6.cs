        public ReportingService()
        {
            GlobalNotifier.EnvironmentChanged += new VoidEventHandler(GlobalNotifier_EnvironmentChanged);
        }
        void GlobalNotifier_EnvironmentChanged()
        {
            //reset settings
            _reportSettings = null;
        }
