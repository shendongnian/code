    public class Company
    {
        public string CompanyName;
        public int Code, Total;
        public Company(string company, int code, int total)
        {
            this.CompanyName = company; this.Code = code;
            this.Total = total;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var Companies = new Company[] {
                new Company("One", 1, 10),
                new Company("Two", 1, 5),
                new Company("Two", 2, 8)
            };
            Accordion1.DataSource = Companies
                .GroupBy(c => c.CompanyName, c => new { Code = c.Code, Total = c.Total },
                (k, enumerable) => new { Key = k, Values = enumerable });
            Accordion1.DataBind();
        }
    }
