        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private bool disableEdit;
        public bool DisableEdit
        {
            get { return disableEdit; }
            set { SetProperty(ref disableEdit, value); }
        }
    }
