    public class AccountSelectedMessage : NotificationMessageAction<bool>
    {
        public AccountSelectedMessage(Account selectedAccount, Action<bool> callback) : base("AccountSelectedWithCancelCallback", callback)
        {
            SelectedAccount = selectedAccount;
        }
        public AccountSelectedMessage(object sender, Account selectedAccount, Action<bool> callback) : base(sender, "AccountSelectedWithCancelCallback", callback)
        {
            SelectedAccount = selectedAccount;
        }
        public AccountSelectedMessage(object sender, object target, Account selectedAccount, Action<bool> callback) : base(sender, target, "AccountSelectedWithCancelCallback", callback)
        {
            SelectedAccount = selectedAccount;
        }
        public Account SelectedAccount { get; private set; }
    }
    
    public class AccountListViewModel : ViewModelBase
    {
        public RelayCommand<Account> AccountSelectedCommand = new RelayCommand<Account>(AccountSelectedCommandExecute);
    
        private void AccountSelectedCommandExecute(Account selectedAccount)
        {
            MessengerInstance.Send(new AccountSelectedMessage(this, AccountSelectionCanceled));
        }
    
        private void AccountSelectionCanceled(bool canceled)
        {
            if (canceled)
            {
                // cancel logic here
            }
        }
    }
    
    public class SomeOtherViewModel : ViewModelBase
    {
        public SomeOtherViewModel()
        {
            MessengerInstance.Register<AccountSelectedMessage>(this, AccountSelectedMessageReceived);
        }
    
        private void AccountSelectedMessageReceived(AccountSelectedMessage msg)
        {
            bool someReasonToCancel = true;
            msg.Execute(someReasonToCancel);
        }
    }
