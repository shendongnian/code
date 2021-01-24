    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lvProjects.DataSource = ProjectService.GetAll();
                lvProjects.DataBind();
            }
        }
