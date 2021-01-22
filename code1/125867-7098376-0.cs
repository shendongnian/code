        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertiesChanged(params string[] Properties)
        {
            if (PropertyChanged != null)
                foreach (string property in Properties)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
