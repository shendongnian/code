        private string firstArgument;
        public string FirstArgument
        {
            get
            {
                return this.firstArgument;
            }
            set
            {
                this.firstArgument= value;
                int tempInt;
                if (int.TryParse(value, out tempInt))
                {
                    this.Model.FirstArgument = tempInt;
                }
                this.NotifyPropertyChanged();
            }
        }
