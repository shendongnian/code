      bool started;
        public bool Started
        {
            get { return started; }
            set { started = value;
            OnStarted(EventArgs.Empty);
            }
        }
