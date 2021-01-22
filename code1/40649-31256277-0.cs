        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                string displayMem = this.DisplayMember;
                base.DataSource = value;
                if (string.IsNullOrEmpty(this.DisplayMember) && string.IsNullOrEmpty(displayMem)) 
                    this.DisplayMember = displayMem;
                DetermineDropDownWidth();
            }
        }
