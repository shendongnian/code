    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string prm_string = Convert.ToString(Request.QueryString["regno"]);
            if (prm_string != null)
            {
                string[] words = prm_string.Split(',');
                txt_regno.Text = words[0];
                txt_board.Text = words[2];
                txt_college.Text = words[3];
            }
        }
    }
