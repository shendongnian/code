    public class CustomerSite
    {
        public CustomerSite(string customer, string site)
        {
            Customer = customer;
            Site = site;
        }
        public string Customer { get; set; }
        public string Site { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var listCustomerSite = new List<CustomerSite>()
            {
                new CustomerSite("SAMSUNG", "CHINA"),
                new CustomerSite("SAMSUNG", "AMERICA"),
                new CustomerSite("SAMSUNG", "AFRICA"),
                new CustomerSite("LG", "CHINA"),
                new CustomerSite("APPLE", "AMERICA"),
                new CustomerSite("APPLE", "CHINA")
            };
            var list = from cs in listCustomerSite
                       group cs by cs.Customer into g
                       orderby g.Key
                       select $"{g.Key} ({string.Join(", ", g.OrderBy(c => c.Site).Select(c => c.Site))})";
            Console.WriteLine(string.Join(", ", list));
            Console.ReadKey();
        }
    }
