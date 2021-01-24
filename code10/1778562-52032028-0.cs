    public LayoutDocumentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] 
            string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _name;
        public string Name
        {
          get { return _name; }
          set
          {
              _name = value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged("Name");
          }
        }
    }
