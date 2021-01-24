using (SqlDataReader dr = cmd.ExecuteReader())
{
    DataTable dt = new DataTable();
    dt.Load(dr); 
    if (dt.Rows.Count > 0)
    {
        Submit_dd.DataSource = dt;  
        Submit_dd.DataBind();  
        Submit_dd.DataTextField = "EmpName_vc";
        Submit_dd.DataValueField = "EmpId_Int";
        Submit_dd.DataBind();
        Submit_dd.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    Cnn.Close();
}
This will solve your problem. 
