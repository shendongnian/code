    public static void Main()    
    {        
      string scriptDirectory = "c:\\temp\\sqltest\\";
      string sqlConnectionString = "Integrated Security=SSPI;" +
      "Persist Security Info=True;Initial Catalog=Northwind;Data Source=(local)";
      DirectoryInfo di = new DirectoryInfo(scriptDirectory);
      FileInfo[] rgFiles = di.GetFiles("*.sql");
      foreach (FileInfo fi in rgFiles)
      {
            FileInfo fileInfo = new FileInfo(fi.FullName);
            string script = fileInfo.OpenText().ReadToEnd();
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(connection));
            server.ConnectionContext.ExecuteNonQuery(script);
       }
    }
