    public partial class TestPage : System.Web.UI.Page 
    {
        private static Random _random = new Random();
        static List<string> lst = new List<string>();
        protected void Page_Load(object sender, EventArgs e) 
        {
            
            
            if (!Page.IsPostBack)
            {
                for (int i = 1; i <= 30; i++)
                {
                    lst.Add(RandomString(i));
                }
                
                GridView1.DataSource = lst;
                GridView1.DataBind();
                SetPageNumbers();
            }
        }
        private void SetPageNumbers()
        {
            if (GridView1.PageIndex == 0)
            {
                (GridView1.BottomPagerRow.FindControl("btnPreviousPage")as LinkButton).Enabled = false;
             }
            if(GridView1.PageIndex ==GridView1.PageCount-1)
            {
                (GridView1.BottomPagerRow.FindControl("btnNextPage") as LinkButton).Enabled = false; 
            }
        }
        protected void ChangePage(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Prev":
                    GridView1.PageIndex = GridView1.PageIndex - 1;
                    break;
                case "Next":
                    GridView1.PageIndex = GridView1.PageIndex + 1;
                    break;
            }
            GridView1.DataSource = lst;
            GridView1.DataBind();
            SetPageNumbers();
        }
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                //26 letters in the alfabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65))));
            }
            return builder.ToString();
        }
        
    }
