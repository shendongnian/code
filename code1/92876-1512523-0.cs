    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DetailsView1.DefaultMode = DetailsViewMode.Insert;
                if (DetailsView1.FindControl("TextBox1") != null)
                {
                    TextBox txt1 = (TextBox)DetailsView1.FindControl("TextBox1");
                    txt1.Text = User.Identity.Name.ToString();
                }
            }
        }
