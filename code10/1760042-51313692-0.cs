    public List<string> ValidateNames(List<string> inputList, List<string> patternList)
    {
        var missMatchInputList = new List<string>();
    
        foreach (var input in inputList)
            foreach (var pattern in patternList)
                if (!Regex.IsMatch(input, pattern))
                {
                    missMatchInputList.Add(input);
                    break;
                }
    
        return missMatchInputList;
    }
