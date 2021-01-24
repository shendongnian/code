     protected void Page_Load(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"YOUR CONNECTION STRING");
                if (!IsPostBack)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNTRY FROM COUNTRIES", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr["COUNTRY "].ToString());
                    }
                    dr.Close();
                    con.Close();
                }
            }
     protected void Button1_Click(object sender, EventArgs e)
            {
                Label1.Text = DropDownList1.SelectedItem.Text;
            }
