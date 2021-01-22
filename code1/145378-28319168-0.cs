                    string str = "Backup Database  [" + database + "] To Disk =N'" + file_name + "'";// With Format;' + char(13),'') From  Master..Sysdatabases  Where [Name] Not In ('tempdb','master','model','msdb') and databasepropertyex ([Name],'Status') = 'online'";
                    SqlCommand cmd1 = new SqlCommand(str, con);
                    int s1 = cmd1.ExecuteNonQuery();
                    con.Close();               
                    if (s1 >= -1)
                        MessageBox.Show("Database Backup Sucessfull.", "Hotel Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Database Backup Not Sucessfull.", "Hotel Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
}
