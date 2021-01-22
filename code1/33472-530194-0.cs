        private string cvstrEmptyText = "";
        [Category("Custom")]
        [Description("Displays a message in the DataGridView when no records are displayed in it.")]
        [DefaultValue(typeof(string), "")]
        public string EmptyText
        {
            get
            {
                return this.cvstrEmptyText;
            }
            set
            {
                this.cvstrEmptyText = value;
            }
        }
