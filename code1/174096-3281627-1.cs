    public interface ITransaction { void Process(); }
    public class TransactionProcessor
    {
        public void ProccessTransaction(ITransaction t) { t.Process(); }
    }
