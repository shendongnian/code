    // you have to include the R type in the declaration of the Mapper interface
    public interface IMapper<T, R> {
        T Map<R>(R obj);
    }
    
    // You have to specify both IMapper implementations in the declaration
    public class BillHistoryMapper : IMapper<Account, Invoice>, IMapper<Account, Payment> {
        public BillHistory Map<Invoice>(Invoice obj) {
            // mapping code
        }
        public BillHistory Map<Payment>(Payment obj) {
            // mapping code
        }
    }
