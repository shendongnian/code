    public class Loan
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        //etc..
    }
    public class LoanWithClient
    {
        public Loan Loan { get; set; }
        public Client Client { get; set; }
    }
    return new LoanWithClient
    {
         Loan = loan,
         Client = client
    };
