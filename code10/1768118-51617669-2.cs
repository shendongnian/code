    public class Data
    {
        public string CUSTOMER_NUMBER { get; set; }
        public string CUSTOMER_NAME { get; set; }
    }
    public class NameList
    {
        public string CustomerId { get; set; }
    }
    public class InterCompanies
    {
        public string CustomerId { get; set; }
    }
    public class Test
    {
        public void TMP()
        {
            var data = new List<Data>();
            var genericNameList = new List<NameList>();
            var intercompanies = new List<InterCompanies>();
            var commissions = data
                .GroupJoin(genericNameList,
                    d => d.CUSTOMER_NUMBER,
                    g => g.CustomerId,
                    (d, g) => new { d, generic = g.FirstOrDefault() })
                .GroupJoin(intercompanies,
                    dd => dd.d.CUSTOMER_NAME,
                    i => i.CustomerId,
                    (d, i) => new { data = d.d, intercompanies = i.FirstOrDefault() })
                .ToList();
        }
    }
