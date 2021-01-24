    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\David\\Desktop\\WebApplication5\\WebApplication5\\App_Data\\Database2.mdf\";Integrated Security=True";
        cn = new SqlConnection(str);
        SqlCommand command = cn.CreateCommand();
    
        cn.Open();
        mycount();
        if(!IsPostBack)
        {
            displayData();             
        }
    }
