        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
        openFileDialog.ShowDialog();
        if (!string.IsNullOrEmpty(openFileDialog.FileName))
        {
           string ssqltable = "Student";
           string myexceldataquery = "select Name,DOB,Email from [Sheet1$]";
           try
           {
                //Excel connection string
            string Econn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog.FileName + ";Extended Properties=Excel 12.0;";
                //Sql connection string
            string Sconn = "Data Source=.;Initial Catalog=db_Test;Integrated Security=True";
            using (SqlConnection sqlconn = new SqlConnection(Sconn))
            {
                sqlconn.Open();
                //sqlconn.Close();
                OleDbConnection oledbconn = new OleDbConnection(Econn);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(Sconn);
                bulkcopy.DestinationTableName = ssqltable;
                bulkcopy.WriteToServer(dr);
             }
        }
        finally 
        {
            dr.Close();
            oledbconn.Close();
        }
