    public interface IPrimaryKeyId
    {
        long Id { get; }
    }
    
    public abstract BankPrimaryKeyId : IPrimaryKeyId
    {
        private static long _id;
        public long Id => _id;
        protected BankPrimaryKeyId()
        {
            _id++;
        }
    }    
    
    public class Bank : BankPrimaryKeyId
    {
    }
