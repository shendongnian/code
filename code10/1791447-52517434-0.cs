    //reading from file
    
    int counter = 0;
    
    private void Enter_btn_Click(object sender, EventArgs e)
    {
        // makes a new file called password.txt
        StreamReader sr = new StreamReader("password.txt");
    
    	string usr = "";
    	string pass = "";
    	
    	pass = sr.ReadLine();
    	if(pass != null)
    	{
    		//You get the password here now you can do the logic
    	}
    	else
    	{
    		//There is no line should throw an exception for instance
    	}
    	
    	//Now lets get the username
    	usr = sr.ReadLine();
    	if(usr != null)
    	{
    		//You get the usr here
    	}
    	else
    	{
    		//There is no 2nd line should throw an exception for instance
    	}
    
    }
