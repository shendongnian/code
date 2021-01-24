	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckableEntryView : ContentView
	{
        public event EventHandler<TextChangedEventArgs> TextChanged;
        private BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CheckableEntryView), string.Empty);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue( TextProperty, value); }
        }
        public CheckableEntryView ()
		{
            InitializeComponent();
            
            txtEntry.TextChanged += OnTextChanged;
            txtEntry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.Default, null, null, null, this));
		}
        protected virtual void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            TextChanged?.Invoke(this, args);
        }
        public Task ShowValidationMessage()
        {
            Task.Yield();
            lblContraintText.IsVisible = true;
            return lblContraintText.ScaleTo(1, 250, Easing.SinInOut);
        }
        public Task HideValidationMessage()
        {
            Task.Yield();
            return lblContraintText.ScaleTo(0, 250, Easing.SinInOut)
                .ContinueWith(t => 
                    Device.BeginInvokeOnMainThread(() => lblContraintText.IsVisible = false));
        }
	}
