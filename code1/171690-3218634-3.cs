      bool started;
        public bool Started
        {
            get { return started; }
            set
            {
                started = value;
                if (started)
                    OnStarted(EventArgs.Empty);
            }
        }
