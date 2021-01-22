    public sealed class DeviceManager : INotifyPropertyChanged
    {
        // Singleton members omitted
    
        public IPlayer Player
        {
            get { return player; }
            set
            {
                this.player = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Player"));
            }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    
        #endregion
    }
