    string line="";
    			
    for(int i=0; i<100; i++)
    {
    	string backup=new string('\b',line.Length);
    	Console.Write(backup);
    	line=string.Format("{0}%",i);
    	Console.Write(line);
    }
