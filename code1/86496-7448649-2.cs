    public static class MyExtensionMethods
    {
        public static Dictionary<string, string> MatchNamedCaptures(this Regex regex, string input)
        {
            var namedCaptureDictionary = new Dictionary<string, string>();
            GroupCollection groups = regex.Match(input).Groups;
            string [] groupNames = regex.GetGroupNames();
            foreach (string groupName in groupNames)
                namedCaptureDictionary.Add(groupName,groups[groupName].Value);
            return namedCaptureDictionary;
        }
    }
