    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            viewModel.Msg[0] = "Original message 1";
            viewModel.Msg[1] = "Original message 2";
            viewModel.Msg[2] = "Original message 3";
            viewModel.Msg[3] = "Original message 4";
            viewModel.Msg[4] = "Original message 5";
            BindingContext = viewModel;
        }
    }
    public class MainViewModel : ObservableObject
    {
        private Messages _msg;
        public Messages Msg
        {
            get { return _msg ?? (_msg = new Messages()); }
            set { SetProperty(ref _msg, value); }
        }
        public ICommand UpdateMessage => new Command(() =>
               {
                   Msg[2] = "New message 3";
                   Msg[0] = "New message 1";
               });
    }
