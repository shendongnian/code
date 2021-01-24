    public interface IFService {
        string _OID { get; set; }
        decimal _Amount{ get; set; }
        TransactionResponse Search(string criteria);
    }
