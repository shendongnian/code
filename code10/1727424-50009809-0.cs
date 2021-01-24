    public class PaymentClass {
        public int ID;
        public string Name;
        public double Payment;
        public int? ParentPaymentId;
    }
    
    public class PaymentWithChildren {
        public int ID;
        public string Name;
        public double Payment;
        public int? ParentPaymentId;
        public PaymentClass[] Payments;
    }
