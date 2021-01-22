    public static Dictionary<string, object> ParseJsonToDictionary(string json)
    {
        var d = new Dictionary<string, object>();
        if (json.StartsWith("{"))
        {
            json = json.Remove(0, 1);
            if (json.EndsWith("}"))
                json = json.Substring(0, json.Length - 1);
        }
        json.Trim();
        // Parse out Object Properties from JSON
        while (json.Length > 0)
        {
            var beginProp = json.Substring(0, json.IndexOf(':'));
            json = json.Substring(beginProp.Length);
            var indexOfComma = json.IndexOf(',');
            string endProp;
            if (indexOfComma > -1)
            {
                endProp = json.Substring(0, indexOfComma);
                json = json.Substring(endProp.Length);
            }
            else
            {
                endProp = json;
                json = string.Empty;
            }
            var curlyIndex = endProp.IndexOf('{');
            if (curlyIndex > -1)
            {
                var curlyCount = 1;
                while (endProp.Substring(curlyIndex + 1).IndexOf("{") > -1)
                {
                    curlyCount++;
                    curlyIndex = endProp.Substring(curlyIndex + 1).IndexOf("{");
                }
                while (curlyCount > 0)
                {
                    endProp += json.Substring(0, json.IndexOf('}') + 1);
                    json = json.Remove(0, json.IndexOf('}') + 1);
                    curlyCount--;
                }
            }
            json = json.Trim();
            if (json.StartsWith(","))
                json = json.Remove(0, 1);
            json.Trim();
            // Individual Property (Name/Value Pair) Is Isolated
            var s = (beginProp + endProp).Trim();
        
            // Now parse the name/value pair out and put into Dictionary
            var name = s.Substring(0, s.IndexOf(":")).Trim();
            var value = s.Substring(name.Length + 1).Trim();
            if (name.StartsWith("\"") && name.EndsWith("\""))
            {
                name = name.Substring(1, name.Length - 2);
            }
            double valueNumberCheck;
            if (value.StartsWith("\"") && value.StartsWith("\""))
            {
                // String Value
                d.Add(name, value.Substring(1, value.Length - 2));
            }
            else if (value.StartsWith("{") && value.EndsWith("}"))
            {
                // JSON Value
                d.Add(name, ParseJsonToDictionary(value));
            }
            else if (double.TryParse(value, out valueNumberCheck))
            {
                // Numeric Value
                d.Add(name, valueNumberCheck);
            }
            else
                d.Add(name, value);
        }
        return d;
    }
