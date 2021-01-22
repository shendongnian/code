    public void MakeConnection() {
        string ConnectionString = "Host=" + HOST + "; " +
         "Service=" + SERVICENUM + "; " +
         "Server=" + SERVER + "; " +
         "Database=" + DATABASE + "; " +
         "User Id=" + USER + "; " +
         "Password=" + PASSWORD + "; ";
        
        IfxConnection conn = new IfxConnection();
        conn.ConnectionString = ConnectionString;
        try {
            conn.Open();
            Console.WriteLine("Made connection!");
            Console.ReadLine();
        } catch (IfxException ex) {
            Console.WriteLine("Problem with connection attempt: "
                              + ex.Message);
        }
    }
