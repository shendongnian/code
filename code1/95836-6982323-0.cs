        if(ddlClient.SelectedItem.Text!="Select")
        {
        
        //Page.Validate("AdvancePayment");
        ////Page.Validate("Project");
        //Page.Validate("group3");
        if (Page.IsValid)
        {
            bool bolSuccess = false;
            SqlTransaction SqlTrn;
            SqlConnection con = new SqlConnection(CommonStrings.ConnectionString);
            con.Open();
            SqlTrn = con.BeginTransaction();
            try
            {
                bool bolUpdate;
                int intParameterLength;
                bolUpdate = ((ViewState["Project_ID"] == null) ? false : true);
                if (bolUpdate == true)
                {
                    intParameterLength = 2;
                }
                else
                {
                    intParameterLength = 1;
                }
                object objProjectCost;
                objProjectCost = CommonFunctions.GetDbNull(txtProjectCost.Text);
                ExecuteProcedures ex = new ExecuteProcedures(intParameterLength);
                ex.Parameters.Add("@Client_ID", SqlDbType.Int, ddlClient.SelectedValue);
                //ex.Parameters.Add("@vcrProject", SqlDbType.VarChar, ddlProject.SelectedItem.Text);
                //ex.Parameters.Add("@numRate", SqlDbType.Float, Convert.ToDouble(txtProjectCost.Text));
                //ex.Parameters.Add("@vcrShort_Description", SqlDbType.VarChar, txtShortDesc.Text);
                //ex.Parameters.Add("@numAdvance_Amount", SqlDbType.Float, Convert.ToDouble(txtAdvanceAmount.Text));
                //ex.Parameters.Add("@Date", SqlDbType.DateTime, Convert.ToDateTime(txtAdvanceDate.Text));
                //ex.Parameters.Add("@PaymentDetails", SqlDbType.VarChar, txtPayment.Text);
                string strProcedure = "proc_Add_Client_Order";
                if (bolUpdate == true)
                {
                    strProcedure = "proc_Update_Client_Order_new";
                    ex.Parameters.Add("@Client_Project_ID", SqlDbType.VarChar, Convert.ToString(ViewState["Project_ID"]));
                }
                string ID = Convert.ToString(ex.InvokeProcedure(strProcedure, SqlTrn, ValueDataType.Number, con));
                if (bolUpdate == true)
                {
                    ID = ViewState["Project_ID"].ToString();
                }
                if (GridView1.Rows.Count > -1)
                {
                    Dentry de = new Dentry();
                    string strSql = "Delete from Client_Order_Advance_Payment where Client_Order_ID=" + ID;
                    de.RunCommand(strSql, SqlTrn, con);
                    foreach (GridViewRow grdRow in GridView1.Rows)
                    {
                        Label lbld = (Label)grdRow.FindControl("lblPayment_Date");
                        string strDate = lbld.Text;
                        string strAmount = grdRow.Cells[1].Text;
                        //string strDate = ((Label)grdRow.FindControl("lblPayment_Date")).Text;
                        //string strExpectedDate = grdRow.Cells[4].Text;
                        Label lbled = (Label)grdRow.FindControl("lblExpectedPayment_Date");
                        string strExpectedDate = lbled.Text;
                        //string strExpectedDate = ((Label)grdRow.FindControl("lblExpectedPayment_Date")).Text;
                        string strPaymentDetails = grdRow.Cells[0].Text;
                        string ExpectedTime = grdRow.Cells[5].Text;
                        string DispatchedTime = grdRow.Cells[3].Text;
                        strSql = "Insert into Client_Order_Advance_Payment(numAdvance_Amount,dtPayment_Date,Client_Order_ID,";
                        strSql += "vcrPayment_Details,dtExpectedPayment_Date,ExpTime,Dispath_Time,Enquiry_ID) values(" + strAmount + ",'" + Convert.ToDateTime(strDate) + "'," + ID + ",'" + strPaymentDetails + "','" + Convert.ToDateTime(strExpectedDate) + "','" + ExpectedTime + "','" + DispatchedTime + "'," + ID + ")";
                        de.RunCommand(strSql, SqlTrn, con);
                    }
                }
                if (GridView2.Rows.Count > -1)
                //if (GridView2.Rows.Count > -1)
                {
                    Dentry de = new Dentry();
                    string strSql = "Delete from Client_Ordered_Projects where Client_Order_ID=" + ID;
                    de.RunCommand(strSql, SqlTrn, con);
                    foreach (GridViewRow grdRow in GridView2.Rows)
                    {
                        string strProject = grdRow.Cells[0].Text;
                        string strRate = grdRow.Cells[1].Text;
                        string strDescription = grdRow.Cells[2].Text;
                        strSql = "Insert into Client_Ordered_Projects(vcrProject,numRate,vcrDescription,Client_Order_ID,Enquiry_ID" +
                            ") values('" + strProject + "'," + strRate + ",'" + strDescription + "'," + ID + "," + ID + ")";
                        de.RunCommand(strSql, SqlTrn, con);
                    }
                }
                SqlTrn.Commit();
                bolSuccess = true;
            }
            catch
            {
                SqlTrn.Rollback();
            }
            con.Close();
            if (bolSuccess == true)
            {
                Response.Redirect("Client_Order_Grid.aspx");
            }
        }
        }
        else
        {
            CommonFunctions.Alert("Plz. Select the Client",this.Page);
        }
    }
