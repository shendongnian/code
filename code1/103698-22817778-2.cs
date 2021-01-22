    internal bool OleDbWork(string connString, string command,
    out OleDbCommand myAccessCommand, Action action)
        {
            OleDbConnection myAccessConn = null;
            myAccessCommand = null;
            try
            {
                myAccessConn = new OleDbConnection(connString);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database!");
                
                return false;
            }
            try
            {
                myAccessCommand = new OleDbCommand(command, myAccessConn);
                
                myAccessConn.Open();
                
                action();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot retrieve data from database. \n{0}",
                ex.Message);
                
                return false;
            }
            finally
            {
                myAccessConn.Close();
            }
        }
