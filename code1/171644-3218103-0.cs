    string connection_string="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Documents and Settings\CJP\My Documents\Visual Studio 2005\WebSites\NewElligibleSoft\elligiblity.mdb;Persist Security Info=False";
    using(OleDbConnection cn = new OleDbConnection(connection_string))
    {
                cn.Open();
                string sql = "UPDATE main SET s_name=?,inst_code=?,ms_oms=?,elligiblity=?,Board=?,percentage=?,amount=? WHERE elg_id =?";
                using(OleDbCommand cmd = new OleDbCommand(sql, cn))
    {
    cmd.Parameters.Add(new OleDbParameter("s_name",TextBox1.Text.Trim()));
    cmd.Parameters.Add(new OleDbParameter("inst_code",DropDownList1.SelectedItem.Value.ToString()));
    cmd.Parameters.Add(new OleDbParameter("ms_oms",Label7.Text.ToString()));
    cmd.Parameters.Add(new OleDbParameter("elligiblity",Label12.Text));
    cmd.Parameters.Add(new OleDbParameter("Board",DropDownList5.SelectedItem.Value.ToString()));
    cmd.Parameters.Add(new OleDbParameter("percentage",DropDownList5.SelectedItem.Value.ToString()));
    cmd.Parameters.Add(new OleDbParameter(amount",DropDownList5.SelectedItem.Value.ToString()));
    cmd.Parameters.Add(new OleDbParameter("elg_id",DropDownList5.SelectedItem.Value.ToString()));
    cmd.ExecuteNonQuery();
    cn.Close();
    }
    }        
     Response.Write("alert('DATA UPDATED')");
