    [Serializable]
    public class MyLinks
    {
        public string cLink;
        public string cTitle;
    }
    
    public partial class Dokimes_StackOverFlow_AplesDokimes : System.Web.UI.Page
    {
        MyLinks [] MyLinksAre = {
                new MyLinks{cLink = "products.aspx", cTitle = "products"},
                new MyLinks{cLink = "ProductCat.aspx", cTitle = "catalog"},
                new MyLinks{cLink = "Paradeigma.aspx", cTitle = "example"},
        
        };
        
    
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sRenderOnMe = new StringBuilder();
            int menuID = 0;
            switch (menuID)
            {
                case 0:
                    foreach (int i in new int[] { 0, 1 })
                        sRenderOnMe.AppendFormat("<a href=\"{0}\">{1}</a>", MyLinksAre[i].cLink, MyLinksAre[i].cTitle);
                    break;
    
    
                default:
                    foreach (int i in new int[] { 0, 1, 2 })
                        sRenderOnMe.AppendFormat("<a href=\"{0}\">{1}</a>", MyLinksAre[i].cLink, MyLinksAre[i].cTitle);
                    break;
            }
    
            txtMenouRender.Text = sRenderOnMe.ToString();
        }
    }
