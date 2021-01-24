        private string ConnString;
        private string Context;
        public Factory(IConfig config)
        {
            this.ConnString = config.Connstring;
            this.Context = config.Context;
        }
