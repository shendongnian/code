    string sqltable = "dbo.SLT_C60Staging";
    string[] importfiles = Directory.GetFiles(@"K:\jl\load\dest", "*.txt");
    // try to wrap your ADO.NET stuff into using() statements to automatically 
    // dispose of the SqlConnection after you're done with it
    using(SqlConnection con = new SqlConnection("Data Source=Cove;Initial Catalog=GS_Ava_MCase;Integrated Security=SSPI"))
    {
       // define the SQL insert statement and use parameters
       string sqlStatement = 
          "INSERT INTO dbo.YourTable(DateField, TimeField, TextField) VALUES(@Date, @Time, @Text)";
       // define the SqlCommmand to do the insert - use the using() approach again  
       using(SqlCommand cmd = new SqlCommand(sqlStatement, con))
       {
          // define the parameters for the SqlCommand 
          cmd.Parameters.Add("@Date", SqlDbType.DateTime);
          cmd.Parameters.Add("@Time", SqlDbType.DateTime);
          cmd.Parameters.Add("@Text", SqlDbType.VarChar, 1000);
          // loop through all files found
          foreach (string importfile in importfiles)
          {
             // read the lines from the text file
             string[] allLines = File.ReadAllLines(importfile);
             con.Open();
       
             // start counting from index = 1 --> skipping the header (index=0)
             for (int index = 1; index < allLines.Length; index++)
             {
                // split up the data line into its parts, using "|" as separator
                // items[0] = date
                // items[1] = time
                // items[2] = text
                string[] items = allLines[index].Split(new char[] { '|' });
                cmd.Parameters["@Date"].Value = items[0];
                cmd.Parameters["@Time"].Value = items[1];
                cmd.Parameters["@Text"].Value = items[2];
                cmd.ExecuteNonQuery();
             }
             con.Close();
          }
       }
    }
