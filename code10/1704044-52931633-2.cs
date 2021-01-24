    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryLabelView : ContentView
	{
		public EntryLabelView ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty ValidatableObjectProperty = BindableProperty.Create(
            nameof(ValidatableObject), typeof(ValidatableObject<string>), typeof(EntryLabelView), default(ValidatableObject<string>),
            BindingMode.TwoWay,
            propertyChanged: (b, o, n) => ((EntryLabelView)b).ValidatableObjectChanged(o, n));
        public ValidatableObject<string> ValidatableObject
        {
            get { return (ValidatableObject<string>)GetValue(ValidatableObjectProperty); }
            set { SetValue(ValidatableObjectProperty, value); }
        }
        void ValidatableObjectChanged(object o, object n)
        {
            ValidatableObject = (ValidatableObject<string>)n;
            OnPropertyChanged(nameof(ValidatableObject));
        }
        public static readonly BindableProperty ValidateCommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(EntryLabelView), null,
            propertyChanged: (b, o, n) => ((EntryLabelView)b).CommandChanged(o, n));
        public ICommand ValidateCommand
        {
            get { return (ICommand)GetValue(ValidateCommandProperty); }
            set { SetValue(ValidateCommandProperty, value); }
        }
        void CommandChanged(object o, object n)
        {
            ValidateCommand = (ICommand)n;
            OnPropertyChanged(nameof(ValidateCommand));
        }
    }
