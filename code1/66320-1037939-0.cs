    string[] args = new string[] {"-u:username", "-dbs:servername", "-dbu:dbuser", "-dbp:dbpassword"};
    
    string user = null;
    int divisionid = 0;
    string mysqlPwd = null;
    
    foreach (string arg in args)
    {
        string[] parts = arg.Split(':');
    
        switch (parts[0].ToUpper())
        {
            case "-U":
                user = parts[1];
                break;
            case "-D":
                divisionid = Int32.Parse(parts[1]);
                break;
            case "-DBP":
                mysqlPwd = parts[1];
                break;
                // ....
            default:
                // Display usage
                break;
        }
    }
    
    Debug.WriteLine(string.Format("User {0} | Password {1}", user, mysqlPwd));
