    public static string CheckDuplicate(string text)
    {
        var textArray = text.Split('-');    
        int[] textArrayNum = textArray.Select(s => int.Parse(s)).ToArray();
        if (textArrayNum.Length != textArrayNum.Distinct().Count()) 
        {
            result = "Duplicate";  // no re-declaration, reference to the static field
        }
        else
        {
            result = "No Duplicate";  // no re-declaration, reference to the static field
        }
        return result;  // references the static field
    }
