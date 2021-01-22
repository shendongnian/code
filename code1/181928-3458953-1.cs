    void Method() 
    {  
        string str = "\\Mesg"; 
        str = Method1(str);  
        Console.WriteLine(str); 
    }
    string Method1(string s)
    {
        string upadtedString = s;
        if (s.Contains(@"\\")
        {
         //do nothing
        }
        else if(s.Contains(@"\"))
        {
              s = upadtedString.Replace(@"\",@"\\");//Change around here
        }
        return s;
    } 
