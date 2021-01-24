    StreamReader sr = new StreamReader("password.txt");
    string user;
    while((user = sr.ReadLine()) != null)  
    {  
        string password;
        if ((password = sr.ReadLine()) == null) {
            // TODO: Throw some exception for example Illegal State.
        }
        if (string.Equals(user, #user)) {
            if (string.Equals(password , #password)) {
                sr.Close();
                // SUCCESS
            } else {
                // WRONG PASSWORD
            }
        }
    }
    sr.Close();
    // WRONG USER
    
