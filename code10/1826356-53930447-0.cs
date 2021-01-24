    public interface ILoan
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string PropertyAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //etc..
    }
        
    public interface IClient
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        // etc..
    }
    
    public interface IClientWithLoan: IClient, ILoan
    {
    }
    
    public sealed class ClientWithLoan: IClientWithLoan
    {
        // here place the real implementation
    }
