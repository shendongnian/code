        public Boolean Value
        {
            get
            {
                return Settings.Default.Value;
               
            }
            set
            {
                Settings.Default.SomeValue= value;
                Settings.Default.Save();
                Notify("SomeValue");
            }
        }
