    public class TransactionService : ITransactionService {
        private readonly IMRepository _mRepository;
        private readonly IFService fGateway;
    
        public TransactionService(IMbaRepository mbaRepository, IFService fService) {
            _mRepository = mRepository;
            fGateway = fService;
        }
    
        public List<Transaction> SearchTransacionsByUser(FUser objFUser) {    
            foreach (var item in something) {
                TransactionOperationInput input = new TransactionOperationInput() {
                    Criteria = _criteria,
                    OID =  objFUser.OID.ToString(),
                    Amount = objFUser.Amount,
                };
                 _fGateway.Search(input);
                //...
             }
    
            //...
        }
    }
