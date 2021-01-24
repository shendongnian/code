    class Program
    {
        public static StockMarket stockMarket = new StockMarket();
        static void Main(string[] args)
        {
           
        }
    }
    public interface ICompany
    {
        string Name { get; }
    }
    public class StockMarket
    {
        public StockMarket()
        {
            Companies = SomeWildFunctionThatRetrievesAllCompanies();
        }
        public void OneWildFunctionThatModifiesACompany()
        {
            Company dunno = (Company)Companies[0];
            dunno.Name = "Modification Made Possible";
        }
        private List<ICompany> SomeWildFunctionThatRetrievesAllCompanies()
        {
            return new List<ICompany>(new List<Company>());
        }
        public List<ICompany> Companies { get; private set; }
        private class Company : ICompany
        {
            public string Name { get; set; }
        }
    }
