    class ViewModel :INotifyPropertyChanged
    {
        private StringBuilder _Text = new StringBuilder();
        public string Text
        {
            get { return _Text.ToString(); }
            set
            {
                _Text = new StringBuilder( value);
                OnPropertyChanged("Text");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            var eh = this.PropertyChanged;
            if(null != eh)
            {
                eh(this,new PropertyChangedEventArgs(propName));
            }
        }
        private void TextWriteLine(string text,params object[] args)
        {
            _Text.AppendLine(string.Format(text,args));
            OnPropertyChanged("Text");
        }
        private void TextWrite(string text,params object[] args)
        {
            _Text.AppendFormat(text,args);
            OnPropertyChanged("Text");
        }
        private void TextClear()
        {
            _Text.Clear();
            OnPropertyChanged("Text");
        }
    }
