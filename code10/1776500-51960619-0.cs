        public string Name { get; set; }
        AnotherCustomCollection<IBaseField> IScreen.Fields
        {
            get
            {
                return default(AnotherCustomCollection<IBaseField>);
            }
        }
        CustomCollection<IField> ITable.Fields
        {
            get
            {
                return default(CustomCollection<IField>);
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
    }
