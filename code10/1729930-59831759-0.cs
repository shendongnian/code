    private void propertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsInitialized")
        {
            init();
        }
    }
