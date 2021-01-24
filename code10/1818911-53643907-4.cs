    //Get the current path from where the exe is running.
    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    //Build path to Database folder
    var databasePath = currentDirectory + "Database";
    //Assign it to DataDirectory
    AppDomain.CurrentDomain.SetData("DataDirectory", databasePath);
    var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
    Console.WriteLine(dataDirectory);
    //Use DataDirectory to SQL Connection.
    SqlConnection conn = new SqlConnection(@"Data Source=.;AttachDbFilename=|DataDirectory|\HomeDB.mdf;Integrated Security=True");
    conn.Open();
