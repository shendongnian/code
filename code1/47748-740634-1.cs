    partial class Person : INotifyPropertyChanged
    {
        bool _IsSleeping, _IsSitting;
        public bool IsSleeping 
        { 
            get { return _IsSleeping; } 
            set 
            {
                if(_IsSleeping != value)
                {
                    _IsSleeping = value;
                    OnIsSleepingChanged();
                }
            }
        }
        public bool IsSitting 
        { 
            get { return _IsSitting; } 
            set 
            {
                if(_IsSitting != value)
                {
                    _IsSitting = value;
                    OnIsSittingChanged();
                }
            }
        }
        protected virtual void OnIsSleepingChanged()
        {
            NotifyPropertyChanged("IsSleeping");
            CheckCanJumpChanged();
        }
        protected virtual void OnIsSittingChanged()
        {
            NotifyPropertyChanged("IsSitting");
            CheckCanJumpChanged();
        }
        bool CanJump_Old;
        public bool CanJump { get { return !(IsSleeping || IsSitting); } }
        void CheckCanJumpChanged()
        {
            if(CanJump != CanJump_Old)
            {
                CanJump_Old = CanJump;
                NotifyPropertyChanged("CanJump");
            }
        }
        
        //INotifyPropertyChanged helper method
        private void NotifyPropertyChanged(String prop)
        {
            var hand = PropertyChanged;
            if (hand != null)
                hand(this, new PropertyChangedEventArgs(prop));
        }
    }
