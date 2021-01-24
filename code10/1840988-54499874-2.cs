    public partial class HeaderTemplate : ContentView
    {
        public HeaderTemplate()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ImageSource2Property =
            BindableProperty.Create(nameof(ImageSource2), 
                                    typeof(string), 
                                    typeof(HeaderTemplate), 
                                    defaultValue: default(string), 
                                    propertyChanged: OnImageSourcePropertyChanged);
        public string ImageSource2
        {
            get => (string)GetValue(ImageSource2Property);
            set => SetValue(ImageSource2Property, value);
        }
        public static readonly BindableProperty ImageSource2TapCommandProperty =
            BindableProperty.Create(
                                    propertyName: nameof(ImageSource2TapCommand),
                                    returnType: typeof(ICommand),
                                    declaringType: typeof(HeaderTemplate),
                                    defaultValue: default(ICommand), 
                                    propertyChanged: OnTapCommandPropertyChanged);
        public ICommand ImageSource2TapCommand
        {
            get => (ICommand)GetValue(ImageSource2TapCommandProperty);
            set => SetValue(ImageSource2TapCommandProperty, value);
        }
        private void ImageSource2_Tapped(object sender, EventArgs e)
        {
            if (ImageSource2TapCommand == null) return;
            if (ImageSource2TapCommand.CanExecute(null))
            {
                ImageSource2TapCommand.Execute(null);
            }
        }
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
    }
