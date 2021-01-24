    public void Button_Submit_Onclick(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["TestDeductionsConnectionString2"].ToString();
                int recordid = Convert.ToInt32(GridView2.DataKeys[i].Values[0]);
                //bool private1 = Convert.ToBoolean(GridView2.FindControl("CheckBox1"));
                CheckBox cbox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
                bool private1 = Convert.ToBoolean(cbox.Checked); 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "Update DetailCosts set private='" + private1 + "' where recordid=" + recordid;
                cmd.Parameters.AddWithValue("@private1", SqlDbType.Bit).Value = private1;
                cmd.Parameters.AddWithValue("@recordid", SqlDbType.Int).Value = recordid.ToString();
                cmd.ExecuteNonQuery();
                
                if (private1==true)
                {
                    //DateTime date = DateTime.Now;
                    //cmd.CommandText = "Update AprovedCosts set AprovedCosts.AprovalUser = ";
                    
                    cmd.CommandText = "Update DetailCosts set privateCost=Costs where recordid=" + recordid;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    
                    cmd.CommandText = "Update DetailCosts set privateCost=0 where recordid=" + recordid;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
