    public class ViewModel : ViewModelBase
    {
        private string _password;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        private bool _showPassword;
        public bool ShowPassword
        {
            get => _showPassword;
            set
            {
                Set(ref _showPassword, value);
                RaisePropertyChanged(nameof(HidePassword));
            }
        }
        public bool HidePassword => !ShowPassword;
    }
