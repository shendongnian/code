    // C#
    // Sample demonstrating the use of ClearPool API in OracleConnection class
     
    using System;
    using Oracle.DataAccess.Client;
     
    class ClearPoolSample
    {
      static void Main()
      {
        Console.WriteLine("Running ClearPool sample..." );
        // Set the connection string
        string strConn = "User Id=scott;Password=tiger;Data Source=oracle;" +
                         "Min pool size=5;";
        OracleConnection conn = new OracleConnection(strConn);
     
        // Open the connection
        conn.Open();
      
        // Clears the connection pool associated with connection 'conn'
        OracleConnection.ClearPool (conn);
     
        // This connection will be placed back into the pool
        conn.Close ();
     
        // Open the connection again to create additional connections in the pool
        conn.Open();
     
        // Create a new connection object
        OracleConnection connNew = new OracleConnection(strConn);
     
        // Clears the pool associated with Connection 'connNew'
        // Since the same connection string is set for both the connections,
        // connNew and conn, they will be part of the same connection pool.
        // We need not do an Open() on the connection object before calling
        // ClearPool
        OracleConnection.ClearPool (connNew);
     
        // cleanup
        conn.Close();
        Console.WriteLine("Done!");
      }
    }
