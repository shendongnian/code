    static void OnTapCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is HeaderTemplate headerTemplate && newValue is ICommand command)
        {
            headerTemplate.ImageSource2TapCommand = command;
        }
    }
    
    static void OnImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is HeaderTemplate headerTemplate && newValue is string imageSource)
        {
            headerTemplate.ImageSource_2.Source = ImageSource.FromFile(imageSource);
        }
    }
