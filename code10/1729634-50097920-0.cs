     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)  
        {  
            if (e.Row.RowType == DataControlRowType.DataRow)  
            {  
                String Sql = @" select Staffid, staffforename, staffsurname, CONCAT(staffforename, ' ', staffSurname) as FullName from Staff where SupportTeamID = 'TEL'";
                SqlConnection conn = new SqlConnection(Properties.Resources.cString);
                SqlDataAdapter DA = new SqlDataAdapter(Sql, Properties.Resources.cString);
                DataSet DS = new DataSet();
                DA.Fill(DS, "STaff");
                DataTable DT = DS.Tables["Staff"];
                gv_Quals.FindControl("cmbStaffID").DataValueField = "StaffID";
                gv_Quals.FindControl("cmbStaffID").DataTextField = "FullName";
                gv_Quals.FindControl("cmbStaffID").DataSource = DT;
                gv_Quals.FindControl("cmbStaffID").DataBind();
            }   
  
       }  
