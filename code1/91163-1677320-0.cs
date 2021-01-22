    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SomeData> data = new List<SomeData>();
    
            data.Add(new SomeData("Bob"));
            data.Add(new SomeData("Joe"));
    
            Repeater1.DataSource = data;
            Repeater1.DataBind();
        }
    
        public String FirstnameColumn {
            get { return "Firstname";  } 
        }
    }
    
    public class SomeData
    {
        public String Firstname { get; set; }
    
        public SomeData(String firstname) {
            this.Firstname = firstname;
        }
    }
