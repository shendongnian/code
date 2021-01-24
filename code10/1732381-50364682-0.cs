    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MagicBox : ContentView
	{
        public static readonly BindableProperty TextProperty =
			BindableProperty.Create("Text", typeof(string), typeof(MagicBox), default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public MagicBox ()
		{
			InitializeComponent ();
		}
	}
