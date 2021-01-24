    DataTable table = new DataTable();
    table.Columns.Add("IP", typeof(string));
    
    table.Rows.Add("127.0.0.1");
    table.Rows.Add("10.70.1.22");
    // generated a table at runtime to create issue quickly.
    
    foreach(DataRow row in table.Rows) // itterate over rows
    {
        try
        {
           IPHostEntry entry = Dns.GetHostEntry(row["IP"].ToString()); // Try get host entry inside loop
           row["IP"] = entry.HostName; // if GetHostEntry find HostName set it to row
        }
        catch(Exception) // if GetHostEntry can't find hostname it will throw error but i removed throw to not terminate the program
        {
        }      
     }
     dataGridView1.DataSource = table; // set as source
