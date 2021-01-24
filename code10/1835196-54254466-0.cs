    public static readonly DependencyProperty ListBoxReadOnlyDependency =
          DependencyProperty.Register("ListBoxReadOnly", typeof(bool),
          typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata
          (false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnChanged)));
    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        AutoCompleteTextBox ctrl = (AutoCompleteTextBox)d;
        var x = ctrl.ListBoxReadOnly;
        //...
    }
 
