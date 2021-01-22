        public ReportingService()
        {
            GlobalNotifier.EnvrionmentChanged += new VoidEventHandler(GlobalNotifier_EnvrionmentChanged);
        }
        void GlobalNotifier_EnvrionmentChanged()
        {
            //reset settings
            _reportSettings = null;
        }
