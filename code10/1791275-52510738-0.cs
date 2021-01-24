    private string dataMode;
        public string DataMode
        {
            get
            {
                if (string.IsNullOrEmpty(dataMode))
                {
                    return "Read";
                }
                return dataMode;
            }
            set
            {
                dataMode = value;
                RaisePropertyChanged("DataMode");
            }
        }
