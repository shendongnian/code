    public static List<int> StringToList(string stringToSplit, char splitDelimiter) 
    { 
        List<int> list = new IntList(); 
 
        if (string.IsNullOrEmpty(stringToSplit)) 
            return list; 
        //this if is not necessary. As others have said, Split will return a string[1] with the original string if no delimiter is found
        if (stringToSplit.Contains(splitDelimiter.ToString())) 
        { 
            string[] values = stringToSplit.Split(splitDelimiter); 
 
            //why check this? if there are no values, the foreach will do nothing and fall through to a return anyway.
            if (values.Length <= 1) 
                return list; 
 
            foreach (string s in values) 
            { 
                int i; 
                if (Int32.TryParse(s, out i)) 
                    list.Add(i); 
            } 
        } 
        //again, this is rendered redundant due to previous comments
        else if (stringToSplit.Length > 0) 
        { 
            int i; 
            if(Int32.TryParse(stringToSplit, out i)) 
                list.Add(i); 
        } 
 
        return list; 
    }
