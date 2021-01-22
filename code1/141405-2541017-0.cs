    private List<string> splitOnLogDelimiter(string bigString)
    {
        Regex r = new Regex("[0-9]{4,4}-[0-9]{2,2}-[0-9]{2,2} [0-9]{2,2}:[0-9]{2,2}:[0-9]{2,2} INFO");
        List<string> result = new List<string>();
        
        //2010-03-26 16:06:38 INFO
        int oldIndex = 0;
        int newIndex = 0;
        foreach (Match m in r.Matches(bigString))
        {
            newIndex = m.NextMatch().Index-1;
            if (newIndex <= 0) break;
            result.Add(bigString.Substring(oldIndex, newIndex - oldIndex));
            
            oldIndex = newIndex+1;
        }
        return result;
        
    }
