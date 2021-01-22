    public class Substitutioner
    {
        private string Template { get; set; }
    
        public Substitutioner(string template)
        {
            this.Template = template;
        }
    
        public string GetResults(object obj)
        {
            // Create the value map and the match list.
            Dictionary<string, object> valueMap = new Dictionary<string, object>();
            List<string> matches = new List<string>();
    
            // Get all matches.
            matches = this.GetMatches(this.Template);
    
            // Iterate through all the matches.
            foreach (string match in matches)
            {
                if (valueMap.ContainsKey(match))
                    continue;
    
                // Get the tag's value (i.e. Test for <%=Test%>.
                string value = this.GetTagValue(match);
    
                // Get the corresponding property in the provided object.
                PropertyInfo property = obj.GetType().GetProperty(value);
                if (property == null)
                    continue;
    
                // Get the property value.
                object propertyValue = property.GetValue(obj, null);
    
                // Add the match and the property value to the value map.
                valueMap.Add(match, propertyValue);
            }
    
            // Iterate through all values in the value map.
            string result = this.Template;
            foreach (KeyValuePair<string, object> pair in valueMap)
            {
                // Replace the tag with the corresponding value.
                result = result.Replace(pair.Key, pair.Value.ToString());
            }
    
            return result;
        }
    
        private List<string> GetMatches(string subjectString)
        {
            try
            {
                List<string> matches = new List<string>();
                Regex regexObj = new Regex("<%=(.*?)%>");
                Match match = regexObj.Match(subjectString);
                while (match.Success)
                {
                    if (!matches.Contains(match.Value))
                        matches.Add(match.Value);
                    match = match.NextMatch();
                }
                return matches;
            }
            catch (ArgumentException)
            {
                return new List<string>();
            }
        }
        
        public string GetTagValue(string tag)
        {
            string result = tag.Replace("<%=", string.Empty);
            result = result.Replace("%>", string.Empty);
            return result;
        }
    }
