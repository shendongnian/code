    public static List<int> StringToList(string stringToSplit, char splitDelimiter) 
    { 
        List<int> list = new IntList(); 
 
        if (string.IsNullOrEmpty(stringToSplit)) 
            return list;
        
        foreach(var s in stringToSplit.Split(splitDelimiter))
        {
            int i;
            if(int.TryParse(s, out i))
                list.Add(i);
        }
        return list;
    }
