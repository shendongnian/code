    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            List<User> list = new List<User>();
            User u = new User();
            u.iduser = 0;
            u.name = "alex";
            u.uContact = "555399";
            u.mail_adress = "fdsfsfdsddsff@gmail.com";
            list.Add(u);
            for (int i = 1; i < 5;i++ )
            {
                u = new User();
                u.iduser = i;
                u.name = "alex "+i;
                u.uContact = "555399";
                u.mail_adress = "fsddfsdsdf@gmail.com";
                list.Add(u);
            }
            list_user.DataSource = list;
            list_user.DataBind();
        }
    }
    class User
    {
        public int iduser { get; set; }
        public string name { get; set; }
        public string mail_adress { get; set; }
        public string uContact { get; set; }
    }
    protected void list_user_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label nom = (System.Web.UI.WebControls.Label)e.Item.FindControl("username") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)e.Item.FindControl("contact") as System.Web.UI.WebControls.Button;
            if (nom.Text == "alex")
            { btn.Enabled = true; }
            else
            { btn.Enabled = false; }
        }
    }
    protected void contact_Click(object sender, EventArgs e)
    {
        //Add for click
    }
