     public string name;
        public string Name
        {
            get { return name; }
            set
            {
                name= value;
                RaisePropertyChanged(nameof(Name));
            }
        }
