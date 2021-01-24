    public static readonly BindableProperty ImageSource2Property =
        BindableProperty.Create(nameof(ImageSource2), 
                                typeof(string), 
                                typeof(HeaderTemplate), 
                                defaultValue: default(string), 
                                propertyChanged: OnImageSourcePropertyChanged);
    public static readonly BindableProperty ImageSource2TapCommandProperty =
        BindableProperty.Create(
                                propertyName: nameof(ImageSource2TapCommand),
                                returnType: typeof(ICommand),
                                declaringType: typeof(HeaderTemplate),
                                defaultValue: default(ICommand), 
                                propertyChanged: OnTapCommandPropertyChanged);
