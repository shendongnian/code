        public class MyTagBuilder : TagBuilder
        {
            public MyTagBuilder(string tagName) : base(tagName){}
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
            private string GetMyAttributesString()
            {
                var builder = new StringBuilder();
                var myDictionary = new SortedDictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in this.Attributes)
                {
                    myDictionary.Add(pair.Key, pair.Value);
                }
                foreach (KeyValuePair<string, string> pair in myDictionary)
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
