    string s = "I have something like this";
    
    //question No. 1
    int pos = s.IndexOf("something");  
    
    //quiestion No. 2
    string[] separator = {"something"};
    string[] leftAndRightEntries = s.Split(separator, StringSplitOptions.None);  
    
    //question No. 3
    
    int x = pos + 10;
    string substring = s.Substring(pos, x);
