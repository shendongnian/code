    //No control over this interface
    public interface IFService {
        TransactionResponse Search(string criteria);
    }
    //Create your own and extend
    public interface IFpnService : IFService {
        string _OID { get; set; }
        decimal _Amount{ get; set; }
    }
    
    public class FService : IFpnService {
        //...
    }
    //...
