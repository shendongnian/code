        public ICommand OnButtonClick
        {
            get
            {
                return new Command(() =>
                {
                    this.Text.Text = "Updated";
                });
            }
        }
