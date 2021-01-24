    var converter = new BooleanToVisibilityConverter();
    var myBinding = new Binding
    {
        Path = new PropertyPath("IsVisiblePropertyInViewModel"),
        Mode = BindingMode.OneWayToSource,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        Converter = converter
    };
    BindingOperations.SetBinding(pane, UIElement.Visibility, binding);
