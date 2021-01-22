    public class Program
        {
            static void Main(string[] args)
            {
                ParserBase parser = new ParserBase();
    
                Console.WriteLine(parser.DynamicRenderControl<HyperLink>(parser.Parse("")));
                Console.ReadLine();
            }
        }
    
        public class ParserBase
        {
            public virtual Dictionary<string, string> Parse(string stringToParse)
            {
                //...
                // parse the stringToParse
                //...
                Dictionary<string, string> parsedPropertiesValues = new Dictionary<string, string>();
                parsedPropertiesValues.Add("NavigateUrl", @"http://www.koolzers.net");
                return parsedPropertiesValues;
            }
    
            protected virtual void SetProperty<T>(T obj, string propertyName, string value) where T : WebControl
            {
                typeof(T).GetProperty(propertyName).SetValue(obj, value, null);
            }
    
    
            public string DynamicRenderControl<T>(Dictionary<string, string> parsedPropertiesValues) where T : WebControl, new()
            {
                StringBuilder sb = new StringBuilder();
                using (T control = new T())
                {
                    foreach (KeyValuePair<string, string> keyValue in parsedPropertiesValues)
                    {
                        SetProperty<T>(control, keyValue.Key, keyValue.Value);
                    }
    
                    using (StringWriter tw = new StringWriter(sb))
                    {
                        using (HtmlTextWriter w = new HtmlTextWriter(tw))
                        {
                            control.RenderControl(w);
                        }
                    }
    
                }
                return sb.ToString();
            }
        }
