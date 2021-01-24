    protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == IsVisibleProperty.PropertyName)
            {
                if (IsVisible) AnimateIn();
                else AnimateOut();
            }
        }
