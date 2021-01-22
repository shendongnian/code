    using System.Data.OleDB;
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
        
        //Create a new oledb connection
        string path = "c:\\yourfilepath\\file.accdb";
        OleDbConnection myConnection = 
            new SqlConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" +
            path + "';");
        myConnection.Open();
        
        //Run the stored proc on each param and output result to file
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"filepath\filename"))
        {
            foreach (string param in paramList)
            {
                //myCommand.CommandText is the query you want to run against your database
                //i.e. the stored proc
                OleDbCommand myCommand = myConnection.CreateCommand();
                myCommand.CommandText = "stored_proc " + param;
                OleDbDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    file.WriteLine("pass: " + param);
                } 
                else 
                {
                    file.WriteLine("fail: " + param);
                }
                myReader.Close();
            }
        }
        myConnection.Close();
    }
