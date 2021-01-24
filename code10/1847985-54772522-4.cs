     public void ProcessPayment()
     {
         var paymentMethods = new List<IPaymentMethod>()
         {
                new CreditCard(),
                new Check()
         };
         var calculations = new PaymentCalculationsVisitor();
         foreach (var paymentMethod in paymentMethods)
         {
            //First i need to get the fee
            var fee = calculations.GetFee(paymentMethod);
            //Then i do do some other stuff, validations, other calculations etc
            //Finally i get the extra charge
            var extraCharge = calculations.GetExtraCharge(paymentMethod);
        }
    }
