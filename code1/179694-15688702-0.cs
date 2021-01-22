    {
        SqlConnection con = new SqlConnection("Data Source=ANSA-PC\\SQLEXPRESS;Initial Catalog=pms;Integrated Security=True");
        String str = "";
        for (int i = 0; i <=CheckBoxList1.Items.Count-1; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                if (str == "")
                {
                    str = CheckBoxList1.Items[i].Text;
                }
                else
                {
                    str += "," + CheckBoxList1.Items[i].Text;
                }
            }
        }
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into aa(a)values('" +str + "')", con);
        cmd.ExecuteNonQuery();
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('ansari:u also got it')</script>");
    }
