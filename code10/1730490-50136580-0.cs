    public System.Windows.Input.ICommand CommandInButton
    {
        get; set;
    }
    public static readonly BindableProperty CommandInButtonProperty =
        BindableProperty.Create(
            propertyName: "CommandInButton",
            returnType: typeof(System.Windows.Input.ICommand),
            declaringType: typeof(CustomControl),
            defaultValue: null,
            propertyChanged: CommandInButtonPropertyChanged);
    private static void CommandInButtonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomControl)bindable;
        control.ButtonInFrame.Command = (System.Windows.Input.ICommand)newValue;
    }
