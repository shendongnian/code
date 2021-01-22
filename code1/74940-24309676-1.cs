    //to run process as another user
    
    //create these global variables on the first
    //form or piece of code in your program
    class usernameGlobalVariable
        {
            public static string var = "";
        }
        class passwordGlobalVariable
        {
            public static SecureString var;
        }
    
    // use these as event handlers for text fields
    //for your login form
    private void usernameTextBox_TextChanged(object sender, EventArgs e)
    {
    	usernameGlobalVariable.var = usernameTextBox.Text;
    }
    
    private void passwordTextBox_TextChanged(object sender, EventArgs e)
    	{
    	SecureString passWord = new SecureString();
    		foreach (char c in passwordTextBox.Text.ToCharArray())
    		{
    		passWord.AppendChar(c);
    		}
    	passwordGlobalVariable.var = passWord;
    	}
    
    	
    	
    //put this on form that launches program
    //this assigns variables for process.start
    //change fileName to path and name of program
    // use \\ in paths
    string fileName = "c:\\hdatools\\Ping2.exe";
    string arguments = "";
    string domain = "domain";
    
    //start the process
    //put this on the page along w the above variables that
    //launches the app as another user
    //the .var variables are global
    {
        Process.Start(
        fileName,
        arguments,
        usernameGlobalVariable.var,
        passwordGlobalVariable.var,
        domain);
    }
