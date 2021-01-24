    public class TransactionService : ITransactionService {
        private readonly IMRepository _mRepository;
        private readonly IFService fGateway;
    
        public TransactionService(IMbaRepository mbaRepository, IFService fService) {
            _mRepository = mRepository;
            fGateway = fService;
        }
    
        private List<Transaction> SearchTransacionsByUser(FUser objFUser) {    
             foreach (var item in something) {
                  _fGateway.OID = objFUser.OID.ToString();
                 _fGateway.Amount = objFUser.Amount;    
                 _fGateway.Search(criteria);
                //...
             }
    
            //...
        }
    }
