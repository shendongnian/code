	class Employee : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged();
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
			var temp = PropertyChanged;
			
            if ( temp != null )
            {
                temp( this, new PropertyChangedEventArgs( caller ) );
            }
        }
    }
