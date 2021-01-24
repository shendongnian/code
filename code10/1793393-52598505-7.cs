    public static string CheckDuplicate(string text)
    {
        var textArray = text.Split('-');    
        int[] textArrayNum = textArray.Select(s => int.Parse(s)).ToArray();
        if (textArrayNum.Length != textArrayNum.Distinct().Count()) 
        {
            return "Duplicate";
        }
        else
        {
            return "No Duplicate";
        }
    }
