    using System.Data.SqlClient;
    try{
        SqlConnection con = new SqlConnection(cs.conn()); 
        string database = con.Database.ToString(); 
        string datasource = con.DataSource.ToString(); 
        string connection = con.ConnectionString.ToString(); 
        string file_name =data_loaction+database_name;
        --- "D:\\Hotel BackUp\\" + database + day + month + year + hour + minute + second + ms + ".bak";
        con.Close();
        con.Open();                
        string str = "Backup Database  [" + database + "] To Disk =N'" + file_name + "'";// With Format;' + char(13),'') From  Master..Sysdatabases  Where [Name] Not In ('tempdb','master','model','msdb') and databasepropertyex ([Name],'Status') = 'online'";
        SqlCommand cmd1 = new SqlCommand(str, con);
        int s1 = cmd1.ExecuteNonQuery();
        con.Close();               
        if (s1 >= -1)
                MessageBox.Show("Database Backup Sucessfull.", "Hotel Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else{
                MessageBox.Show("Database Backup Not Sucessfull.", "Hotel Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
