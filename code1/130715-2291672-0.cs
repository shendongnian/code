var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString());  
var sqlDataAdapter = new SqlDataAdapter("select * from tnm_story_status", sqlConnection);
sqlConnection.Open();  
var dataSet = new DataSet();              
sqlDataAdapter.Fill(dataSet);
sqlConnection.Close();  
var dataTable = dataSet.Tables[0];  
var streamWriter = new StreamWriter(@"C:\db.txt", false);  
var sb = new StringBuilder();  
for (var col = 0; col < dataTable.Columns.Count; col++)  
{  
    if (sb.ToString() != "") sb.Append(",");  
    sb.Append(dataTable.Columns[col].ColumnName);  
}              
streamWriter.WriteLine(sb.ToString());  
sb.Remove(0, sb.ToString().Length);  
for (var row = 0; row < dataTable.Rows.Count; row++ )  
{  
    for (var col = 0; col < dataTable.Columns.Count; col++)  
    {  
        if (sb.ToString() != "") sb.Append(",");  
        sb.Append(dataTable.Rows[row][col].ToString());  
    }  
    streamWriter.WriteLine(sb.ToString());    
    sb.Remove(0, sb.ToString().Length);  
}                         
streamWriter.Close();  
