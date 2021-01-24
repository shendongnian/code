    string str = "PRODUCT MANAGER OFFICE";
    string shortname = "P.M.O";
    
    string compareStr = "";            
    string[] strArry = str.Split(' ');
    
    foreach (string x in strArry)
    {  
    	if(x.Trim() != string.Empty)
    	{
    		compareStr += x[0];
    	}                
    }
    //Console.WriteLine(compareStr);
    
    if(compareStr.Equals((shortname.Replace(".", string.Empty)), StringComparison.InvariantCultureIgnoreCase))
    {
    	Console.WriteLine("valid");
    }
