string rid = Request.QueryString["RID"];
int id = 0;
if (!string.IsNullOrEmpty(rid) && Int32.TryParse(rid, out id))
{
    lblRID.Text = rid;
    SqlCommand myCommand = new SqlCommand("usp_NewResource_get", myConnection);
    myCommand.Parameters.AddWithValue("@RID",id);
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Execute...
}
