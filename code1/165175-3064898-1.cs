    using System.Data.SQLClient;
    using System.IO;
    static int Main(string[] args)
    {
        //Make a list to hold your params
        List<string> paramList = new List<string>();
        
        //Populate the list based on args
        for (int i = 0; i < args.Length(); i++) 
        {
            paramList.Add(args[i]);
        }
        
        //Create a new sql connection
        SqlConnection myConnection = new SqlConnection("yourConnString");
        myConnection.Open();
        
        //Run the stored proc on each param and output result to file
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"filepath\filename"))
        {
            foreach (string param in paramList)
            {
                //The first argument of the SqlCommand ctor is a string which should be identical to the query you want to run against your sql database
                SqlCommand myCommand = new SqlCommand("stored_proc " + param, myConnection);
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    file.WriteLine("pass: " + param);
                } 
                else 
                {
                    file.WriteLine("fail: " + param);
                }
            }
        }
        myConnection.Close();
    }
