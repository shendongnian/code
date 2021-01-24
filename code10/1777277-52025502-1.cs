    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    DropDownList1.DataBind();
                    DropDownList2.DataBind();
                }
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                Calendar1.Visible = true;
            }
    
            protected void Calendar1_SelectionChanged(object sender, EventArgs e)
            {
                tbdates.Text = Calendar1.SelectedDate.ToShortDateString();
                Calendar1.Visible = false;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                if (Request.Cookies["date"] == null)
                {
                    Request.Cookies.Add(new HttpCookie("date"));
                }
                Request.Cookies["date"].Value = tbdates.Text;
            }
