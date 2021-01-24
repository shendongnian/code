        // Reference in the inspector
        public SettingsAsset settings;
        // ...
        // Though I doubt you would need to do this in Update 
        // If you only change the settings from within a separate settings scene
        // you probably should do this only once
        private void Update()
        {
            AudioSrc.volume = settings.musicVolume;
        }
