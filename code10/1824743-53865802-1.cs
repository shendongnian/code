        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.CheckForPropertyErrors();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override void CheckForPropertyErrors()
        {
            this.ValidateInt(this.FirstArgument , nameof(this.FirstArgument ));
        }
        protected void ValidateInt32(string value, string fieldName, string displayName = null)
        {
            int temp;
            if (!int.TryParse(value, out temp))
            {
                this.AddError(new ValidationError(fieldName, Constraints.NotInt32, $"{displayName ?? fieldName} must be an integer"));
            }
            else
            {
                this.RemoveError(fieldName, Constraints.NotInt32);
            }
        }
