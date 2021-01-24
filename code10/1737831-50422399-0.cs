    public class StatusClass  : INotifyPropertyChanged
        {
                  
            public event PropertyChangedEventHandler PropertyChanged;
    
            // This method is called by the Set accessor of each property.
            // The CallerMemberName attribute that is applied to the optional propertyName
            // parameter causes the property name of the caller to be substituted as an argument.
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        private int proprety1 
        public int Proprety1 
        {
            get
            {
                return this.proprety1;
            }
            set
            {
                if (value != this.proprety1)
                {
                    this.proprety1 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
