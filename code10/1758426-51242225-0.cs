    public static void Main(string[] args)
        {
            //your "unmodified" srting
            string text = "{{parameter2}} Today we're {{parameter1}}";
    
            //key = tag(explicitly) value = new string
            Dictionary<string, string> tagToStringDict = new Dictionary<string,string>();
    
            //add tags and it's respective replacement
            tagToStringDict.Add("{{parameter1}}", "Foo");
            tagToStringDict.Add("{{parameter2}}", "Bar");
    
            //this returns your "modified string"
            changeTagWithText(text, tagToStringDict);
        }
    
        public static string changeTagWithText(string text, Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> entry in dict)
            {
                //key is the tag ; value is the replacement
                text = text.Replace(entry.Key, entry.Value);
            }
            return text;
        }
