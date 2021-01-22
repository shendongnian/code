    string input = "OU=3,OU=2,OU=1,DC=Internal,DC=Net";
    string[] split = input.Split(',');
    
    string path = "";
    for (int i=split.Length-1; i>=0; i--)
    {
        path = ((path == "") ? split[i] : split[i] + "," + path);
    	if (path.StartsWith("OU"))
    		DoSomething(path);
    }
