        public class MyTagBuilder : TagBuilder
        {
            //required to inherit from TagBuilder
            public MyTagBuilder(string tagName) : base(tagName){}
            //new hides the original ToString(TagRenderMode renderMode) 
            //The only changes in this method is that all calls to GetAttributesString
            //have been changed to GetMyAttributesString 
            public new string ToString(TagRenderMode renderMode)
            {
                switch (renderMode)
                {
                    case TagRenderMode.StartTag:
                        return string.Format(CultureInfo.InvariantCulture, "<{0}{1}>", new object[] { this.TagName, this.GetMyAttributesString() });
                    case TagRenderMode.EndTag:
                        return string.Format(CultureInfo.InvariantCulture, "</{0}>", new object[] { this.TagName });
                    case TagRenderMode.SelfClosing:
                        return string.Format(CultureInfo.InvariantCulture, "<{0}{1} />", new object[] { this.TagName, this.GetMyAttributesString() });
                }
                return string.Format(CultureInfo.InvariantCulture, "<{0}{1}>{2}</{0}>", new object[] { this.TagName, this.GetMyAttributesString(), this.InnerHtml });
            }
            //Implement GetMyAttributesString where the Attributes are changed to a SortedDictionary
            private string GetMyAttributesString()
            {
                var builder = new StringBuilder();
                var myDictionary = new SortedDictionary<string, string>();     //new
                foreach (KeyValuePair<string, string> pair in this.Attributes) //new
                {                                                              //new
                    myDictionary.Add(pair.Key, pair.Value);                    //new
                }                                                              //new 
                //foreach (KeyValuePair<string, string> pair in this.Attributes)
                foreach (KeyValuePair<string, string> pair in myDictionary)    //changed
                {
                    string key = pair.Key;
                    if (!string.Equals(key, "id", StringComparison.Ordinal) || !string.IsNullOrEmpty(pair.Value))
                    {
                        string str2 = HttpUtility.HtmlAttributeEncode(pair.Value);
                        builder.AppendFormat(CultureInfo.InvariantCulture, " {0}=\"{1}\"", new object[] { key, str2 });
                    }
                }
                return builder.ToString();
            }
        }
