    public string FirstFile 
    {
        get => (string)GetValue(FirstFileProperty);
        private set => SetValue(FirstFilePropertyKey, value);
    }
    private static readonly DependencyPropertyKey FirstFilePropertyKey = 
        DependencyProperty.RegisterReadOnly(nameof(FirstFile), 
            typeof(string), typeof(MainWindow));
    public static readonly DependencyProperty FirstFileProperty = 
        FirstFilePropertyKey.DependencyProperty;
    public string SecondFile 
    {
        get => (string)GetValue(SecondFileProperty);
        private set => SetValue(SecondFilePropertyKey, value);
    }
    private static readonly DependencyPropertyKey SecondFilePropertyKey = 
        DependencyProperty.RegisterReadOnly(nameof(SecondFile), 
            typeof(string), typeof(MainWindow));
    public static readonly DependencyProperty SecondFileProperty = 
        SecondFilePropertyKey.DependencyProperty;
