    string sqltable = "dbo.SLT_C60Staging";
    string[] importfiles = Directory.GetFiles(@"K:\jl\load\dest", "*.txt");
    // try to wrap your ADO.NET stuff into using() statements to automatically 
    // dispose of the SqlConnection after you're done with it
    using(SqlConnection con = new SqlConnection("Data Source=Cove;Initial Catalog=GS_Ava_MCase;Integrated Security=SSPI"))
    {
       // loop through all files found
       foreach (string importfile in importfiles)
       {
          // read the lines from the text file
          string[] allLines = File.ReadAllLines(importfile);
          con.Open();
          // start counting from index = 1 --> skipping the header (index=0)
          for(int index = 1; index < allLines.Length; index++)
          {
             // split up the data line into its parts, using "|" as separator
             string[] items = allLines[index].Split(new char[] {'|'} );
             // here you now need to actually save those parts into SQL
             // use either a SqlCommand with a parametrized query (to avoid SQL injection)
             // and fill in the parameters, or use a stored proc or something 
          }
                    
          con.Close();
       }
    }
