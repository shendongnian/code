    public string test() 
            {
                string result="";
                string[,] Hashtable = new string[2,2]
    {
        {"first_match", "One"},
        {"second_match", "Two"},
       
    };
                string match = "001_first_match";
    
                for (int i = 0; i < Hashtable.GetLength(0); i++)
                {
                   string test1=  Hashtable[i, 0];
                   if (match.Contains(test1)) { result = Hashtable[i, 1]; }
                   
                }
                return result;
            }
