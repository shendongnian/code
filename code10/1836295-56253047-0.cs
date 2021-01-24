     public class AddNewPaymentRequest
     {
         //[EnumDataType(typeof(PaymentStatus))]
         //public string PaymentStatus { get; set; }
    
         public PaymentStatus PaymentStatus { get; set; }
    
         public string Id { get; set; }
     }
