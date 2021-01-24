    private void ConvertXmlToClass()
    {
        try
        {
            XDocument doc = XDocument.Load(@"c:\temp\del.xml");
            string jsonText = JsonConvert.SerializeXNode(doc);
            dynamic dyn = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            dynamic svg = dyn.svg;
            var result = new Svg
            {
                g = new List<G>(),
                svgStyle = GetString(svg, "@style"),
                id = GetString(svg, "@id"),
                x = GetString(svg, "@x"),
                y = GetString(svg, "@y"),
                viewBox = GetString(svg, "@viewBox"),
                cssStyle = GetString(((IDictionary<string, object>)svg)["style"] as ExpandoObject, "#text"),
            };
            foreach (ExpandoObject gObj in svg.g)
            {
                var g = new G
                {
                    Id = GetString(gObj, "@id"),
                };
                if (IsPropertyExist(gObj, "rect"))
                {
                    var rect = ((IDictionary<string, object>)gObj)["rect"] as ExpandoObject;
                    g.Rect = new Rect
                    {
                        Class = GetString(rect, "@class"),
                        id = GetString(rect, "@id"),
                        height = GetString(rect, "@height"),
                        width = GetString(rect, "@width"),
                        x = GetString(rect, "@x"),
                        y = GetString(rect, "@y"),
                    };
                }
                if (IsPropertyExist(gObj, "text"))
                {
                    var txt = ((IDictionary<string, object>)gObj)["text"] as ExpandoObject;
                    g.Text = new Text
                    {
                        Class = GetString(txt, "@class"),
                        id = GetString(txt, "@id"),
                        TextData = GetString(txt, "#text"),
                        transform = GetString(txt, "@transform"),
                    };
                }
                result.g.Add(g);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    private string GetString(ExpandoObject obj, string key)
    {
        return ((IDictionary<string, object>)obj)[key] as string;
    }
    private bool IsPropertyExist(dynamic settings, string name)
    {
        if (settings is ExpandoObject)
            return ((IDictionary<string, object>)settings).ContainsKey(name);
        return settings.GetType().GetProperty(name) != null;
    }
    private class Svg
    {
        public string id { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string viewBox { get; set; }
        public string cssStyle { get; set; }
        public string svgStyle { get; set; }
        public List<G> g { get; set; }
    }
    private class G
    {
        public string Id { get; set; }
        public Rect Rect { get; set; }
        public Text Text { get; set; }
    }
    private class Text
    {
        public string id { get; set; }
        public string transform { get; set; }
        public string Class { get; set; }
        public string TextData { get; set; }
    }
    private class Rect
    {
        public string id { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string Class { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }
