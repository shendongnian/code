      private string name;
        public string Name
        {
            get => name;
            set { SetField(ref name, value, nameof(Name)); }
        }
