        protected override void OnExit(ExitEventArgs e)
        {
            if (Settings.Default.Design != DesignName())
            {
                Settings.Default.Design = DesignName();
                Settings.Default.Save();
            }
                
        }
