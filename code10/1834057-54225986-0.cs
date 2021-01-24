     //This method controls the Drop Down List change event. Underwriter change. 
        protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            GridView1.SelectedIndex = idx;
            string Client = GridView1.SelectedRow.Cells[0].Text;//Client Name
            string NewUw = ddl.Text.ToString();
            int UniqCNT = new Int32();
            UniqCNT = Int32.Parse(GridView1.SelectedRow.Cells[1].Text.ToString()); //UniqClient */
            string ExpPolicyNums = GridView1.SelectedRow.Cells[2].Text;
            int Ub = Int32.Parse(GridView1.SelectedRow.Cells[10].Text);//UniqBroker
            DateTime ExperationDate = DateTime.Parse(GridView1.SelectedRow.Cells[6].Text); //ExpDate
            string Company = GridView1.SelectedRow.Cells[7].Text; //Company issuer
            string Broker = GridView1.SelectedRow.Cells[8].Text;  //Broker_Name
            string Premium = GridView1.SelectedRow.Cells[3].Text; //Premiums
            string TotalPremium = GridView1.SelectedRow.Cells[4].Text; //Total premiums
            string Reviewed = "No"; //Updates the DB and shows that it hasn't been reviewed by the Message Creator
                                    //DateCreated gets inserted when record is created 
            string InsertedBy = Request.LogonUserIdentity.Name.Substring(Request.LogonUserIdentity.Name.LastIndexOf(@"\") + 1);
            DateTime dateUpDated = DateTime.Now; //Inserts a dateUpdated record
            string query = "INSERT INTO [GTU_Apps].[dbo].[Reviewed_Renewal_Policy] (UniqClient, Client, [Expiring_Policies], Premiums, TotalPremium, UniqBroker, ExpDate, NewUw, Company, Broker_Name,  Reviewed, DateUpDated, InsertedBy) " +
                "VALUES (@UniqCNT, @Client, @ExpPolicyNums, @Premium, @TotalPremium, @Ub, @ExperationDate, @NewUw, @Company, @Broker,  @Reviewed, @dateUpDated, @InsertedBy)";
            using (SqlConnection conn = new SqlConnection("Data Source=GTU-BDE01;Initial Catalog=GTU_Apps;Integrated Security=True"))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@UniqCNT", UniqCNT);
                    comm.Parameters.AddWithValue("@Client", Client);
                    comm.Parameters.AddWithValue("@ExpPolicyNums", ExpPolicyNums);
                    comm.Parameters.AddWithValue("@Premium", Premium);
                    comm.Parameters.AddWithValue("@TotalPremium", TotalPremium);
                    comm.Parameters.AddWithValue("@Ub", Ub);
                    comm.Parameters.AddWithValue("@ExperationDate", ExperationDate);
                    comm.Parameters.AddWithValue("@NewUw", NewUw);
                    comm.Parameters.AddWithValue("@Company", Company);
                    comm.Parameters.AddWithValue("@Broker", Broker);
                    comm.Parameters.AddWithValue("@Reviewed", Reviewed);
                    comm.Parameters.AddWithValue("@dateUpDated", dateUpDated);
                    comm.Parameters.AddWithValue("@InsertedBy", InsertedBy);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            GridView1.DataBind();  
            GridView1.SelectedIndex = -1;
            int index = DropDownList1.SelectedIndex;
            ConfirmIndex(index);
            //End(sender, e);
        }
