    class PaymentProcessor
    {
        private IPaymentProcessor _processor = null;
        public PaymentProcessor(IPaymentProcessor processor)
        {
            _processor = processor;
        }
    
        public bool ProcessTransaction(Transaction trans)
        {
           _processor.ProcessPayment(trans.amount, ...);
        }
    }
