    public class OrderDTO {
        public CustomerInfo Customer {get;set;}
        public DateTime OrderTime {get;set}
        public DateTime ShipTime {get;set;}
        public List<LineItemDTO> LineItems {get; private set;}
    }
    
    public class LineItemDTO {
        public int LineItemNumber {get;set;}
        public string ProductName {get;set;}
        public int Quantity {get;set}
        public Decimal Amount {get;set}
        public Decimal ExtendedAmount {get;set;}
    }
