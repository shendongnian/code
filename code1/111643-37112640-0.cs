    private ICommand _merchantRefereneceCommand;
    public ICommand MerchantReferenceCopyToClipboard
        {
            get { return _merchantRefereneceCommand ?? (_merchantRefereneceCommand = new MerchantRefereneceCommand(this)); }
            set { _merchantRefereneceCommand = value; }
        }
    public class MerchantRefereneceCommand : ICommand
        {
            private readonly PaymentViewModel _paymentViewModel;
            public MerchantRefereneceCommand(PaymentViewModel paymentViewModel)
            {
                _paymentViewModel = paymentViewModel;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                //Your code goes here.
            }
            public event EventHandler CanExecuteChanged;
        }
