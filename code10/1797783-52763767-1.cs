    private static List<int> ExtratctCordinates(string input)
    {
        List<int> retObj = new List<int>();
        if(!string.IsNullOrEmpty(input))
        {
            int tempHolder;
            // Use below foreach with simple regex if you want sign insensetive data
            //foreach (Match match in new Regex(@"[\d]+").Matches(input))
            foreach (Match match in new Regex(@"[0-9\+\-]+").Matches(input))
            {
                if (int.TryParse(match.Value, out tempHolder))
                {
                    retObj.Add(tempHolder);
                }
            }
        }
        return retObj;          
    }
