    public readonly DependencyProperty IsCheckedProperty =
                DependencyProperty.Register(
                "IsChecked" ...
    
    public Boolean IsChecked
    ... if (value != IsChecked) SetValue(IsCheckedProperty, value); ChangeImage();
