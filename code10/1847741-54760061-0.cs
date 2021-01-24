    public static JObject GetObjectByValue(string filePath, string matchValue)
            {
                var text = File.ReadAllText(filePath);
    
                var pattern = @"\[(.*?)\]";
    
                var matches = Regex.Matches(text, pattern);
    
                foreach (Match item in matches)
                {
                    JArray jArray = JArray.Parse(item.Value);
    
                    var result = jArray.ToObject<JObject[]>().Where(x => x.Properties().Any(y => y.Name == "sym" && y.Value.ToString() == matchValue)).FirstOrDefault();
    
                    if (result != null)
                        return result;
                }
    
                return null;
    
            }
    
