    public class PersonTransactionService {
    
        private readonly IDbSet<Transaction> _allTransactions;
    
        public PersonTransactionService(IDbSet<Transaction> allTransactions) {
            _allTransactions = allTransactions;
        }
    
        public void Commit(Person person, Transaction transaction) {
            transaction.Commit();
    
            var mostRecent = _allTransactions
                .Where(t => t.PersonId == person.Id)
                .OrderBy(t => t.Timestamp)
                .LastOrDefault();
    
            if (mostRecent != null) {
                person.LastTransactionTimestamp = mostRecent.Timestamp;
            }
        }
    }
