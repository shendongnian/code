    public class AccountViewModel : ViewModelBase
    {
        string _balance = "1111$";
        public AccountViewModel(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        public string AccountNumber { get; }
        public string Balance
        {
            get { return _balance; }
            set { SetAndRaisePropertyChanged(ref _balance, value); }
        }
    }
