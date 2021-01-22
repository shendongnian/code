    public class BillHistoryMapper :
        IMapper<Invoice, BillHistory>, IMapper<Payment, BillHistory>
    {
        public BillHistory Map<Invoice>(Invoice obj) {}
        public BillHistory Map<Payment>(Payment obj) {}
    }
