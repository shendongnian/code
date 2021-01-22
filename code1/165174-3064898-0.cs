    using System.Data.SQLClient;    
    static int Main(string[] args)
    {
        string param1 = args[0];
        //repeat as necessary
        SqlConnection myConnection = new SqlConnection(connString);
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(/*Your query goes here*/, myConnection);
        string response = myCommand.ExecuteScalar().ToString();
        myConnection.Close();
    }
