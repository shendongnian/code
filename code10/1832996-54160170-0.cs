    string[] st=File.ReadAllLines("path");
    int c = 0;
    
    List<string> words = new List<string>();
    
    foeach (string s in st){
    	string[] split = s.Split(' ');
    	foreach(string word in split){
    		words.add(word);
    	}
    }
    
    foreach (string s in words)
    {
    	foreach (string line in File.ReadAllLines("path"))
    	{
    		if (line.Contains(s))
    		{
    			c++; 
    		}
    	}
    }
