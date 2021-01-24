    public partial class SampleAppPage : ContentPage<ThisPageViewModel>
    {
        public SampleAppPage()
        {
            InitializeComponent();
            BindingContext = new ThisPageViewModel();
        }
    }
