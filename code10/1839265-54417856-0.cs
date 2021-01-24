    private static void MostraPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (VolosLoading)bindable;
        if (control != null)
        {
            control.LoadingContainer.IsEnabled = (bool)newValue;
            control.LoadingContainer.IsVisible = (bool)newValue;
        }
    }
