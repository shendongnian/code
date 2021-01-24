        private State _playState;
        public State PlayState
        {
            get { return _playState; }
            set {
                SetProperty(ref _playState, value);
                RaisePropertyChanged(nameof(IsPlaying));
                RaisePropertyChanged(nameof(IsPaused));
                RaisePropertyChanged(nameof(IsStopped));
            }
        }
        public bool IsPlaying
        {
            get { return _playState == State.Playing; }
        }
        public bool IsPaused
        {
            get { return _playState == State.Paused; }
        }
        public bool IsStopped
        {
            get { return _playState == State.Stopped; }
        }
