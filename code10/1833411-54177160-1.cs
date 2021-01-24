            ...
            // Keep Sql Readable
            // Do not fetch unwanted columns - * 
            string userTesting = 
              @"select UserName 
                  from NayaTable";
            // Wrap IDisposable into using
            using (db.cmd = new SqlCommand(userTesting, db.DBconnect)) {
              // Wrap IDisposable into using
              using(SqlDataReader myReader = db.cmd.ExecuteReader()) {
                // we are going to build one string from many records
                StringBuilder sb = new StringBuilder();
                // Here, we have to loop and aggregate / collect all the records
                while (myReader.Read()) {
                  if (sb.Length > 0)
                    sb.Append(", "); // delimiter 
                  sb.Append(Convert.ToString(myReader["USERNAME"])); 
                }
                // Here you'll get usernames like "Sam, John, Mary" 
                textBox1.Text = sb.ToString(); 
              }
            }
