    public class ViewModel : BindableBase
    {
        public DelegateCommand<double?> ProcessAmount { get; set; }
    
        public ViewModel()
        {
            ProcessAmount = new DelegateCommand<double?>(HandleProcessAmount, CanProcessAmount);
        }
    
        private bool CanProcessAmount(double? amount)
        {
            return amount.HasValue && amount.Value != 0;
        }
    
        private void HandleProcessAmount(double? amount)
        {
            decimal amountInDecimal = Convert.ToDecimal(amount.Value); // convert it to decimal
            // do something with the amount
        }
    }
