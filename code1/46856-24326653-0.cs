            DatabaseName = "[" + DatabaseName + "]";
            string fileUNQ = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() +"_"+ DateTime.Now.Hour.ToString()+ DateTime.Now .Minute .ToString () + "_" + DateTime .Now .Second .ToString () ;
            BackUpFileName = BackUpFileName + fileUNQ + ".bak";
            string SQLBackUp = @"BACKUP DATABASE " + DatabaseName + " TO DISK = N'" + BackUpLocation + @"\" + BackUpFileName + @"'";
            // Declare sqlconn,sqlcmd, show progresss execute non query 
            string svr = "Server=" + ServerName + ";Database=master;Integrated Security=True";
            SqlConnection cnBk = new SqlConnection(svr);
            SqlCommand cmdBkUp = new SqlCommand(SQLBackUp, cnBk);
 
            try
            {
                cnBk.Open();
                cmdBkUp.ExecuteNonQuery();
                Label1.Text = "Done";
                Label2.Text = SQLBackUp + " ######## Server name " + ServerName + " Database " + DatabaseName + " successfully backed up to " + BackUpLocation + @"\" + BackUpFileName + "\n Back Up Date : " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
                Label2.Text = SQLBackUp + " ######## Server name " + ServerName + " Database " + DatabaseName + " successfully backed up to " + BackUpLocation + @"\" + BackUpFileName + "\n Back Up Date : " + DateTime.Now.ToString();
            }
 
            finally
            {
                if (cnBk.State == ConnectionState.Open)
                {
                
                    cnBk .Close(); 
                } 
            } 
        }
